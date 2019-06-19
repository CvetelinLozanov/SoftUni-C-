using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    //TODO
    public abstract class DBContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        public DBContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        internal static Type[] AllowedSqlTypes =
        {
            typeof(bool),
            typeof(int),
            typeof(string),
            typeof(uint),
            typeof(DateTime),
            typeof(decimal),
            typeof(double),
            typeof(long),
            typeof(ulong),
        };

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(x => !IsObjectValid(x))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (var dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DBContext)
                            .GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException ioe)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DBSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var columns = this.connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }
        }

        private string GetTableName(Type tableType)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;

            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }
        
        private bool IsObjectValid(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(e, validationContext, validationResults, true);
        }

        private void MapAllRelations()
        {
            foreach (var dbSetProperty in dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;

                var mapRelations = typeof(DBContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                var dbSet = dbSetProperty.Value.GetValue(this);

                mapRelations.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DBSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            var collections = entityType
                .GetProperties()
                .Where(pi =>
                pi.GetType().IsGenericType &&
                pi.GetType().GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionType = collection.GetType()
                    .GetGenericArguments()
                    .First();

                var mapCollection = typeof(DBContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollection.Invoke(this, new object[] { dbSet, collectionType });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DBSet<TDbSet> dbSet, PropertyInfo collectionProperty)
                where TDbSet : class, new() where TCollection : class, new()        
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType.GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            var primaryKey = primaryKeys.First();

            var foreignKey = entityType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());
               

            var isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pi => collectionType
                    .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                    .PropertyType == entityType);                    
            }

            var navigationDbSet = (DBSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                var primaryKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet
                    .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(primaryKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(this, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DBSet<TEntity> dbSet) where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            var foreignKeys = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                var navigationPropertyName = foreignKey
                    .GetCustomAttribute<ForeignKeyAttribute>().Name;
                var navigationProperty = entityType.GetProperty(navigationPropertyName);

                var navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);

                var navigationPrimarykey = navigationProperty.PropertyType.GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currentNavigationProperty => navigationPrimarykey.GetValue(currentNavigationProperty).Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private void InitializeDbSets()
        {
            foreach (var dbSetProperty in this.dbSetProperties)
            {
                var dbSetType = dbSetProperty.Key;
                var dbSetPropertyType = dbSetProperty.Value;

                var populateDbSetGeneric = typeof(DBContext)
                    .GetMethod("PopulateDbSet", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetPropertyType });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            var tableEntities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DBSet<TEntity>(tableEntities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);

        }
   

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class
        {
            var table = typeof(TEntity);

            var columns = GetColunmnNames(table);

            var tableName = GetTableName(table);

            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();

            return fetchedRows;
        }

        private string[] GetColunmnNames(Type table)
        {
            var tableName = GetTableName(table);

            var dbColumns = this.connection.FetchColumnNames(tableName);

            var columns = table.GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) &&
                pi.HasAttribute<NotMappedAttribute>() &&
                AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();


            return columns;
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            return this.GetType().GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DBSet<>))
                .ToDictionary(k => k.PropertyType.GetGenericArguments().First(), v => v);
        }               
    }
}
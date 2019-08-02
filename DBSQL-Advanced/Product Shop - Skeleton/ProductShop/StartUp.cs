namespace ProductShop
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using ProductShop.Data;
    using Models;
    using ProductShop.DTOs.Export;
    using System.Collections.Generic;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}";

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            string validCategoriesProductsJson = File.ReadAllText(@"C:\Users\Stavrim\Desktop\Product Shop - Skeleton\ProductShop\Datasets\categories-products.json");

            var result = GetUsersWithProducts(context);

            Console.WriteLine(result);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();


            return string.Format(ImportMessage, users.Length);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return string.Format(ImportMessage, products.Length);

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            var validCategories = new List<Category>();

            foreach (var category in categories)
            {
                if (category.Name == null ||
                    category.Name.Length < 3 ||
                    category.Name.Length > 15)
                {
                    continue;
                }
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return string.Format(ImportMessage, validCategories.Count);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var validCategoryIds = context
                .Categories
                .Select(c => c.Id)
                .ToHashSet();

            var validProductsIds = new HashSet<int>(
                context
                .Products
                .Select(prop => prop.Id)
                );

            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            var validEntities = new List<CategoryProduct>();

            foreach (var categoryProduct in categoriesProducts)
            {
                bool isValid = validCategoryIds.Contains(categoryProduct.CategoryId) &&
                                validProductsIds.Contains(categoryProduct.ProductId);

                if (isValid)
                {
                    validEntities.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validEntities);
            context.SaveChanges();

            return string.Format(ImportMessage, validEntities.Count);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                 .Products
                 .Where(p => p.Price >= 500 && p.Price <= 1000)
                 .Select(p =>
                 new ProductDto
                 {
                     Name = p.Name,
                     Price = p.Price,
                     Seller = $"{p.Seller.FirstName} {p.Seller.LastName}".Trim()
                 })
                 .OrderBy(p => p.Price)
                 .ToList();

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var filteredUsers = context
                 .Users
                 .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                 .OrderBy(u => u.LastName)
                 .ThenBy(u => u.FirstName)
                 .Select(u =>
                 new
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.ProductsSold
                         .Where(ps => ps.Buyer != null)
                         .Select(ps => new
                         {
                             Name = ps.Name,
                             Price = ps.Price,
                             BuyerFirstName = ps.Buyer.FirstName,
                             BuyerLastName = ps.Buyer.LastName
                         })
                         .ToArray()
                 }).ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(
                filteredUsers,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver
                });

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var filteredUsers = context
               .Users
               .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
               .OrderBy(u => u.ProductsSold.Count(ps => ps.Buyer != null))
               .Select(u => new
               {
                   LastName = u.LastName,
                   Age = u.Age,
                   SoldProducts = new
                   {
                       Count = u.ProductsSold
                    .Count(pr => pr.Buyer != null),
                       Products = u.ProductsSold
                    .Where(pr => pr.Buyer != null)
                         .Select(ps => new
                         {
                             Name = ps.Name,
                             Price = ps.Price
                         })
                        .ToArray()
                   }
               }).ToArray();

            var result = new
            {
                UsersCount = filteredUsers.Length,
                Users = filteredUsers
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }
    }
}
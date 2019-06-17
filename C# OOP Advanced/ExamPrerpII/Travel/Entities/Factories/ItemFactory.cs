namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string itemType)
        {
            var assembly = Assembly.GetCallingAssembly();
         
            var type = assembly.GetTypes().FirstOrDefault(x => x.Name == itemType);

            IItem item = (IItem)Activator.CreateInstance(type);

            return item;
        }
    }
}

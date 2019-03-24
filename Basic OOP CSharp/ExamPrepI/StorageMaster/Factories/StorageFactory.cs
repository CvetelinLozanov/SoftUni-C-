using StorageMaster.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            type = type.ToLower();
            Storage storage = null;

            switch (type)
            {
                case "automatedwarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "distributioncenter":
                    storage = new DistributionCenter(name);
                    break;
                case "warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");                
            }

            return storage;
        }
    }
}

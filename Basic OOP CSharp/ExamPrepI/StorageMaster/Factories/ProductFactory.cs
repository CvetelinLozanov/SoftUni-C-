using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            type = type.ToLower();
            Product product = null;

            switch (type)
            {
                case "gpu":
                    product = new Gpu(price);
                    break;
                case "harddrive":
                    product = new HardDrive(price);
                    break;
                case "ram":
                    product = new Ram(price);
                    break;
                case "solidstatedrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");                   
            }

            return product;
        }
    }
}

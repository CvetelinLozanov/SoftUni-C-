using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Mammals.Felines.Factory
{
    public class FelineFactory
    {
        public Feline CreateFeline(string name, double weight,
            string livingRegion, string breed, string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "tiger":
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals.Birds;

namespace WildFarm.Animals.Factory
{
    public class BirdFactory
    {
        public Bird CreateBird(string name, double weight, double wingSize,
            string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "hen":
                    return new Hen(name, weight, wingSize);
                case "owl":
                    return new Owl(name, weight, wingSize);
                default:
                    return null;
                    
            }
        }
    }
}

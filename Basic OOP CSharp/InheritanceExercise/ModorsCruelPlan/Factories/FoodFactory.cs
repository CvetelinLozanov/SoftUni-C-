using ModorsCruelPlan.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModorsCruelPlan.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string type)
        {
            type = type.ToLower();
            switch (type)
            {
                case "cram":
                    return new Cram();
                case "apple":
                    return new Apple();
                case "honeycake":
                    return new HoneyCake();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Junk();
            }
        }
    }
}

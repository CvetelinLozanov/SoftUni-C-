using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat"
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese"
                    && value.ToLower() != "sauce") 
                {
                    string invalidArgument = char.ToUpper(value[0]) +
                        value.Substring(1);
                    Exception ex = new ArgumentException($"Cannot place {invalidArgument} on top of your pizza.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                type = value.ToLower();
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string invalidArgument = char.ToUpper(this.Type[0]) +
                        this.Type.Substring(1);
                    Exception ex = new ArgumentException($"{invalidArgument} weight should be in the range [1..50].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }

        public double ToppingCalories { get => this.GetToppingCalories(); }

        private double GetToppingCalories()
        {
            double modifier = this.Type == "meat" ? 1.2 :
                this.Type == "veggies" ? 0.8 :
                this.Type == "cheese" ? 1.1 : 0.9;
            return this.Weight * 2 * modifier;
        }
    }
}

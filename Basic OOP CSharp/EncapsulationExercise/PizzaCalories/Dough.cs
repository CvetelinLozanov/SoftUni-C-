using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingMethod;
        private double weight;

        public Dough(string flour, string bakingMethod, double weight)
        {
            this.FlourType = flour;
            this.BakingMethod = bakingMethod;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" 
                    && value.ToLower() != "wholegrain")
                {
                    InvalidTypeException();
                }
                flourType = value.ToLower();
            }
        }


        public string BakingMethod
        {
            get { return bakingMethod; }
            set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    InvalidTypeException();
                }
                bakingMethod = value.ToLower();
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }

        public double DoughCalories { get => this.CalculateCalories(); }

        private double CalculateCalories()
        {
            double flourCalories = this.FlourType == "white" ? 1.5 : 1.0;
            double bakingCalories = this.BakingMethod == "crispy" ? 0.9 :
                this.BakingMethod == "chewy" ? 1.1 : 1.0;
            return this.Weight * 2 * flourCalories * bakingCalories;
        }

        private static void InvalidTypeException()
        {
            Exception ex = new ArgumentException("Invalid type of dough.");
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }
}

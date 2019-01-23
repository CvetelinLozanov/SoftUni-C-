using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        //private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 && value.Length > 15)
                {
                    Exception ex = new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }
        public Dough Dough { get => dough; set => dough = value; }
        public List<Topping> Toppings { get; }
       

        public void Add(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                Exception ex = new ArgumentException("Number of toppings should be in range [0..10].");
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            this.Toppings.Add(topping);
        }

        public double Calories { get => CalculateCalories(); }

        private double CalculateCalories()
        {
            double doughCalories = this.Dough.DoughCalories;
            double toppingCalories = this.Toppings.Sum(x => x.ToppingCalories);
            return doughCalories + toppingCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}

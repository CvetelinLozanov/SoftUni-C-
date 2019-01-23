using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] doughInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaInput[1];
            string flourType = doughInput[1];
            string bakingMethod = doughInput[2];
            double doughWeight = double.Parse(doughInput[3]);
            Dough dough = new Dough(flourType, bakingMethod, doughWeight);
            Pizza pizza = new Pizza(pizzaName);
            pizza.Dough = dough;

            string toppingInput = Console.ReadLine();

            while (toppingInput != "END")
            {
                string[] toppingArgs = toppingInput
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string toppingType = toppingArgs[1];
                double toppingWeight = double.Parse(toppingArgs[2]);
                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.Add(topping);
                toppingInput = Console.ReadLine();
            }
            Console.WriteLine(pizza.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
   public class StartUp
    {
        public static List<Car> cars;
        public static List<Engine> engines;
        public static Engine engine;
        public static Car car;
        public static void Main(string[] args)
        {
            cars = new List<Car>();
            engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());
            GetEngines(engineCount);
            int carCount = int.Parse(Console.ReadLine());
            GetCars(carCount);
            PrintCars();
        }

        private static void PrintCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void GetCars(int carCount)
        {
            for (int i = 0; i < carCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = inputArgs[0];
                string engineModel = inputArgs[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                car = new Car(model, engine);

                GetOptionalParametersForCars(inputArgs);
            }
        }

        private static void GetEngines(int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                string[] inpurArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = inpurArgs[0];
                string power = inpurArgs[1];

                engine = new Engine(model, power);
                GetOptionalParametersForEngines(inpurArgs);

            }
        }

        private static void GetOptionalParametersForEngines(string[] inputArgs)
        {
            if (inputArgs.Length == 3)
            {
                if (int.TryParse(inputArgs[2], out int result))
                {
                    engine.Displacement = inputArgs[2];
                }
                else
                {
                    engine.Efficiency = inputArgs[2];
                }
                engines.Add(engine);
            }
            else if (inputArgs.Length == 4)
            {
                string displacement = inputArgs[2];
                string efficiency = inputArgs[3];
                engine.Displacement = displacement;
                engine.Efficiency = efficiency;
                engines.Add(engine);
            }
        }

        private static void GetOptionalParametersForCars(string[] inpurArgs)
        {
            if (inpurArgs.Length == 3)
            {
                if (int.TryParse(inpurArgs[2], out int result))
                {
                    car.Weight = inpurArgs[2].ToString();
                }
                else
                {
                    car.Color = inpurArgs[2];
                }
                cars.Add(car);
            }
            else if (inpurArgs.Length == 4)
            {
                string weight = inpurArgs[2];
                string color = inpurArgs[3];
                car.Weight = weight;
                car.Color = color;
                cars.Add(car);
            }
        }
    }

}

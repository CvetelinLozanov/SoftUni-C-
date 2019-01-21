using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
   public class StartUp
    {
        public static List<Car> cars;
        public static List<Engine> engines;

       public static void Main(string[] args)
        {
            cars = new List<Car>();
            engines = new List<Engine>();
            int engineNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineNumber; i++)
            {
               
                string[] enginesInput = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string engineModel = enginesInput[0];
                int enginePower = int.Parse(enginesInput[1]);
                Engine engine = new Engine(engineModel, enginePower);
                if (enginesInput.Length == 3)
                {
                    if (int.TryParse(enginesInput[2], out int result))
                    {
                        engine.Displacement = result.ToString();
                    }
                    else
                    {
                        engine.Efficiency = enginesInput[2];
                    }                    
                }
                else if (enginesInput.Length == 4)
                {
                    string engineDisplacement = enginesInput[2];
                    string engineEfficiency = enginesInput[3];
                    engine.Displacement = engineDisplacement;
                    engine.Efficiency = engineEfficiency;
                }
                engines.Add(engine);
            }

            int carsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsNumber; i++)
            {
                string[] carsInput = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //model, engine, weight and color
                string carModel = carsInput[0];
                string engineModel = carsInput[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
                Car car = new Car(carModel, engine);
                if (carsInput.Length == 3)
                {
                    if (int.TryParse(carsInput[2], out int result))
                    {
                        car.Weight = carsInput[2].ToString();
                    }
                    else
                    {
                        car.Color = carsInput[2];
                    }
                }
                else if (carsInput.Length == 4)
                {
                    string carWeight = carsInput[2];
                    string carColor = carsInput[3];
                    car.Weight = carWeight;
                    car.Color = carColor;
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

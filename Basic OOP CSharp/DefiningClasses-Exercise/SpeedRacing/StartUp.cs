using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static List<Car> cars;
        public static void Main(string[] args)
        {
            cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputArgs[0];
                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumption = double.Parse(inputArgs[2]);
                Car car = new Car(carModel, fuelAmount, fuelConsumption);
                if (!CheckForSameCar(car))
                {
                    cars.Add(car);
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = commandArgs[1];
                double distanceForTravel = double.Parse(commandArgs[2]);
                foreach (var car in cars)
                {
                    if (CheckForSameCar(car))
                    {
                        if (car.Model == carModel)
                        {
                            car.CanCarMove(distanceForTravel);
                        }                     
                        
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:F2} {car.DistanceTraveled}");
            }

        }
     
        private static bool CheckForSameCar(Car car)
        {
            if (cars.Any(c => c.Model == car.Model))
            {
                return true;
            }
            return false;
        }
    }
}

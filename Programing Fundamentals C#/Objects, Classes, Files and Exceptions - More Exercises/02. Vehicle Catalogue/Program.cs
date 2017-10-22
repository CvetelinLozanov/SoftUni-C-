using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Vehicle_Catalogue
{
    class Program
    {
        static void Main()
        {
            List<Vehicle> vehicles = ReadVehicles();
           
            string vehiclesForPrint = Console.ReadLine();
            List<string> cars = new List<string>();
            while (vehiclesForPrint != "Close the Catalogue")
            {
                cars.Add(vehiclesForPrint);
                vehiclesForPrint = Console.ReadLine();
            }
          
        }

        private static List<Vehicle> ReadVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);
                Vehicle vehicle = new Vehicle
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    HorsePower = horsePower,
                };
                vehicles.Add(vehicle);
                command = Console.ReadLine();
            }
            return vehicles;
        }
    }
    public class Cataloge
    {
        public List<Vehicle> Vehicles { get; set; }
    }
    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }
    }
}
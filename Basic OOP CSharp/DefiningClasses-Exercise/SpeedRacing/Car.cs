using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuel;
        private double fuelConsumption;
        private double distanceTraveled;
        
        public Car(string model, double fuel, double fuelConsumption)
        {
            Model = model;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
            DistanceTraveled = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }          

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }      

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        
        public double DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }

        public void CanCarMove(double distanceForTravel)
        {
            double totalDistanceNeeded = distanceForTravel * fuelConsumption;            
            if (totalDistanceNeeded <= Fuel)
            {
                Fuel -= totalDistanceNeeded;
                DistanceTraveled += distanceForTravel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            
        }
    }
}

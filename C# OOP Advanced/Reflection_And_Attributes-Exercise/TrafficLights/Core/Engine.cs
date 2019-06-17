
namespace TrafficLights.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TrafficLights.Enums;
    using TrafficLights.Models;

    public class Engine
    {
        public void Run()
        {
            var devices = this.SetTrafficLightsDevices();
            var numberOfLightChanges = int.Parse(Console.ReadLine());
            Console.WriteLine(this.ChangeLights(devices, numberOfLightChanges));
        }

        private string ChangeLights(Queue<TrafficLight> devices, int numberOfLightChanges)
        {
            var sb = new StringBuilder();

            while (numberOfLightChanges > 0)
            {
                foreach (var device in devices)
                {
                    device.ChangeLight();
                    sb.AppendLine($"{device.Light} ");
                }

                sb.Remove(sb.Length - 1, 1)
                    .AppendLine();
                numberOfLightChanges--;
            }
            return sb.ToString().Trim();
        }

        private Queue<TrafficLight> SetTrafficLightsDevices()
        {
            var devicesLightsFromInput = Console.ReadLine().Split();
            var devices = new Queue<TrafficLight>();

            foreach (var lightAsString in devicesLightsFromInput)
            {
                LightColors light;
                var isValid = Enum.TryParse(lightAsString, out light);

                if (isValid)
                {
                    devices.Enqueue(new TrafficLight(light));
                }
            }

            return devices;
        }
    }
}

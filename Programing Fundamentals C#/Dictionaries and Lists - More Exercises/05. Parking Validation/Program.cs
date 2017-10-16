using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Parking_Validation
{
    class Program
    {
        static void Main()
        {
            var validateLicenses = new Dictionary<string, string>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string name = commands[1];
                switch (command.ToLower())
                {
                    case "register":
                        var licensePlate = commands[2];
                        Print(Register(validateLicenses, name, licensePlate));
                        break;
                    case "unregister":
                        Print(Unregistered(validateLicenses, name));
                        break;
                }
            }
            foreach (var user in validateLicenses)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }

        private static void Print(string input)
        {
            Console.WriteLine(input);
        }

        private static string Unregistered(Dictionary<string, string> validateLicenses,string name)
        {
            if (!validateLicenses.ContainsKey(name))
            {
                return String.Format($"ERROR: user {name} not found");
            }
            validateLicenses.Remove(name);
            return $"user {name} unregistered successfully";
        }

        private static string Register(Dictionary<string, string> validateLicenses, string name, string licensePlate)
        {
            if (validateLicenses.ContainsKey(name))
            {
                return String.Format($"ERROR: already registered with plate number {validateLicenses[name]}");
            }
            else if (!ValidateLicensePlate(licensePlate))
            {
               return String.Format($"ERROR: invalid license plate {licensePlate}");
            }
            else if (validateLicenses.ContainsValue(licensePlate))
            {
                return String.Format($"ERROR: license plate {licensePlate} is busy");
            }
            validateLicenses.Add(name, licensePlate);
            return string.Format($"{name} registered {licensePlate} successfully");
        }

        private static bool ValidateLicensePlate(string licensePlate)
        {
            bool isValidDigits = licensePlate
                .ToCharArray()
                .Skip(2)
                .Take(4)
                .All(d => char.IsDigit(d));
            bool isValidLetters = licensePlate
                .ToCharArray()
                .Take(2)
                .Concat((licensePlate.ToCharArray().Skip(6).Take(2).ToArray()))
                .All(d => d >= 'A' && d <= 'Z');
            return licensePlate.Length == 8 && isValidDigits && isValidLetters;
        }
    }
}
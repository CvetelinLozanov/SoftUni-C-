using System;
using System.Linq;
using System.Reflection;

namespace BlackBoxInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Type type = typeof(BlackBoxInteger);

            var box = (BlackBoxInteger)Activator
                .CreateInstance(type);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string command = input.Split("_")[0];
                int value = int.Parse(input.Split("_")[1]);

                var method = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.Name == command);

                method.Invoke(box, new object[] { value });

                var result = type
                    .GetFields(BindingFlags.NonPublic
                    | BindingFlags.Instance)
                    .FirstOrDefault(x => x.Name == "innerValue")
                    .GetValue(box);

                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }
    }
}

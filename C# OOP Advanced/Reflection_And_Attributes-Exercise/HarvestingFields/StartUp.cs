namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class StartUp
    {
        static void Main(string[] args)
        {
            Type type = typeof(HarvestingFields);

            string input = Console.ReadLine();

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic
                | BindingFlags.Public | BindingFlags.Instance);

            while (input != "HARVEST")
            {
                if (input != "all")
                {
                    FieldInfo[] fieldsToPrint = fields
                     .Where(f => f.Attributes
                     .ToString()                   
                     .ToLower()
                     .Replace("family", "protected") == input)
                     .ToArray();

                    PrintFields(fieldsToPrint);
                }
                else
                {
                    PrintFields(fields);
                }
                input = Console.ReadLine();
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}

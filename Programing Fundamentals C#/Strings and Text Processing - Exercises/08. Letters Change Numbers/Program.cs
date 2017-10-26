using System;

namespace _08.Letters_Change_Numbers
{
    class Program
    {
        static void Main()
        {
           string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
           double res = 0;
           foreach (var item in input)
           {
               if (!char.IsLetter(item[0]) || !char.IsLetter(item[item.Length - 1]))
               {
                   continue;
               }
               res += CalculateStrings(item);             
                              
           }
            Console.WriteLine($"{res:F2}");
            
        }

        private static double CalculateStrings(string item)
        {
            double res = double.MinValue;
        
            if (char.IsUpper(item[0]))
            {
                res = double.Parse(item.Substring(1, item.Length - 2)) / (((int)item[0]) - 64);
        
            }
            else
            {
                res = double.Parse(item.Substring(1, item.Length - 2)) * (((int)char.ToUpper(item[0])) - 64);
            }
            if (char.IsUpper(item[item.Length - 1]))
            {
                res -= (int)char.ToUpper(item[item.Length - 1]) - 64;
            }
            else
            {
                res += (int)char.ToUpper(item[item.Length - 1]) - 64;
            }
            return res;
        }
    }
}
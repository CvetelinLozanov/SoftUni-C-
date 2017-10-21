using System;
using System.Linq;
using System.IO;

namespace _01.Most_Frequent_number
{
    class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllText("input.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string mostRecentNum = String.Empty;
            int bestLenght = 1;
            
            for (int i = 0; i < input.Length; i++)
            {
                int cnt = 0;
                for (int j = i; j < input.Length; j++)
                {                    
                    string currentNum = input[i];
                    if (currentNum == input[j])
                    {
                        cnt++;
                    }
                    if (cnt > bestLenght)
                    {
                        bestLenght = cnt;
                        mostRecentNum = currentNum;
                    }
                }
                
            }
            File.WriteAllText("output.txt", mostRecentNum);
        }
    }
}
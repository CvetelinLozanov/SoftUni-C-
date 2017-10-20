using System;
using System.IO;
using System.Linq;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main()
        {
            int[] firstFile = File.ReadAllText("FileOne.txt")
                .Split(new char[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondFile = File.ReadAllText("FileTwo.txt")
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] orderedArray = firstFile.Concat(secondFile).OrderBy(n => n).ToArray();
            string[] finalArr = new string[orderedArray.Length];
            for (int i = 0; i < orderedArray.Length; i++)
            {
                finalArr[i] = orderedArray[i].ToString() + Environment.NewLine;
            }
            File.WriteAllText("output.txt", "");
            for (int i = 0; i < finalArr.Length; i++)
            {
                File.AppendAllText("output.txt", finalArr[i]);
            }
           
        }
    }
}
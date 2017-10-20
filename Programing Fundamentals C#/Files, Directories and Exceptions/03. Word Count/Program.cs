using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace _03.Word_Count
{
    class Program
    {
        static void Main()
        {
            string[] wordsToCount = File.ReadAllText("words.txt")
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim()).ToArray();
            string[] text = File.ReadAllText("text.txt")
                .Split(new char[] { ' ', ',', '!', '.', '(', ')', '[', ']', '?', '\r', '\n', '-' })
                .Select(w => w.ToLower())
                .ToArray();
            var wordsCount = new Dictionary<string, int>();
            foreach (var word in wordsToCount)
            {
                wordsCount[word] = 0;
            }
            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            File.WriteAllText("output.txt", "");
            foreach (var word in wordsCount.OrderByDescending(w => w.Value))
            {
                File.AppendAllText("output.txt", word.Key + " -> " + word.Value + Environment.NewLine); 
            }
        }
    }
}
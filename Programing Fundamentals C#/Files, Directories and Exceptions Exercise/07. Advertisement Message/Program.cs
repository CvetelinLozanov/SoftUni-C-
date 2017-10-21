using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _07.Advertisement_Message
{
    class Program
    {
        static void Main()
        {
            string[] authors = File.ReadAllText("author.txt")
                .Split(new char[] { ' ', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();
            string[] phrases = File.ReadAllText("phrases.txt")
             .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(p => p.Replace("\"", ""))
                .Select(p => p.Trim())
                .ToArray();
            string[] events = File.ReadAllText("events.txt")
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Replace("\"", ""))
                 .Select(e => e.Trim())
                .ToArray();
            string[] cities = File.ReadAllText("cities.txt")
                .Split(new char[] { ' ', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim())
                .ToArray();
            int[] num = File.ReadAllText("input.txt")
                .Split()
                .Select(int.Parse)
                .ToArray();
            Random rnd = new Random();
            int n = num[0];
            File.Delete("output.txt");
            for (int i = 0; i < n; i++)
            {
                //{phrase} {event} {author} – {city}.
                string phrase = phrases[rnd.Next(0, phrases.Length)];
                string author = authors[rnd.Next(0, authors.Length)];
                string city = cities[rnd.Next(0, cities.Length)];
                string eventt = events[rnd.Next(0, events.Length)];

                File.AppendAllText("output.txt", phrase + " " + eventt + " " + author + " - " + city + Environment.NewLine);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Models.Contracts;

namespace TestApp.Models
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Models.Contracts;

namespace TestApp.Models
{
    public class ConsoleWriter : IWriter

    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}

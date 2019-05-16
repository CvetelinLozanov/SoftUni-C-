using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestApp.Models.Contracts;

namespace TestApp.Models
{
    public class FileWriter : IWriter
    {

        private const string FilePath = "log.txt";

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}

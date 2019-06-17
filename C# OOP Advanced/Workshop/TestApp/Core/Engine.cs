using SoftuniDI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Core.Contracts;
using TestApp.Models.Contracts;

namespace TestApp.Core
{
    public class Engine : IEngine
    {
        [Inject]
        private IReader reader;
        [Inject]
        [Named("FileWriter")]
        private readonly IWriter fileWriter;
        [Inject]
        [Named("ConsoleWriter")]
        private readonly IWriter consoleWriter;

        //[Inject]
        //public Engine(IReader reader, [Named("FileWriter")] IWriter fileWriter, IReader consoleReader)
        //{
        //    this.reader = reader;
        //    this.fileWriter = fileWriter;
        //    this.consoleReader = consoleReader;
        //}

        public void Run()
        {
            var readInput = this.reader.Read();
            this.consoleWriter.Write(readInput);
            this.fileWriter.Write(readInput);
        }
    }
}

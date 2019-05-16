using SoftuniDI.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Models;
using TestApp.Models.Contracts;

namespace TestApp.Modules
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}

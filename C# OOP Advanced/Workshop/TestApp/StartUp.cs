using Microsoft.Extensions.DependencyInjection;
using SoftuniDI;
using System;
using TestApp.Core;
using TestApp.Core.Contracts;
using TestApp.Models;
using TestApp.Models.Contracts;
using TestApp.Modules;

namespace TestApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var injector = DependencyInjector.CreateInjector(new Module());

            var engine = injector.Inject<Engine>();

            engine.Run();
        }           
    }
}

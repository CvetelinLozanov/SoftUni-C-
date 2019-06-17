using SoftuniDI.Injectors;
using SoftuniDI.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftuniDI
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}

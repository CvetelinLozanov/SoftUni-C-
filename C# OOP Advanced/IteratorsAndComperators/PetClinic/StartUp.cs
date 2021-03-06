﻿namespace PetClinic
{
    using PetClinic.Core.Contracts;
    using PetClinic.Core;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}

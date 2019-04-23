namespace SolidLogger
{
    using SolidLogger.Core;
    using SolidLogger.Core.Contracts;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}

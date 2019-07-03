using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                //DbInitializer.Seed(context);
                ICommandInterpreter commandInterpreter = new CommandInterpreter();
                IEngine engine = new Engine(commandInterpreter);
                engine.Run();
            }
        }
    }
}

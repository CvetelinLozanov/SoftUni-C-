
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;


    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private bool isRunning;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            this.isRunning = true;

            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string commandResult;
                try
                {
                    commandResult = this.ProcessCommand(input);
                  
                }
                catch(TargetInvocationException ex)
                {
                    commandResult = "ERROR: " + ex.InnerException.Message;
                }
                catch (Exception ex)
                {                    
                    commandResult = "ERROR: " + ex.Message;
                }
                this.writer.WriteLine(commandResult);
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var command = tokens[0];
            var args = tokens
                .Skip(1)
                .ToArray();

            string result;

            if (command == "LetsRock")
            {
                var setovete = this.setCоntroller.PerformSets();
                result = setovete;
            }
            else
            {
                var festivalControllerMethod = this.festivalCоntroller
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                result = (string)festivalControllerMethod.Invoke(this.festivalCоntroller, new object[] { args });
            }

            return result;
        }
    }
}
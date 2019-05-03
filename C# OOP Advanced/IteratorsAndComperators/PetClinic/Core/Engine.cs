namespace PetClinic.Core
{
    using PetClinic.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        private StringBuilder finalResult;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.finalResult = new StringBuilder();
        }

        public void Run()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string clinicName = string.Empty;
                string petName = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "Create":
                            this.ProcessCreation(inputArgs.Skip(1).ToArray());
                            break;
                        case "Add":
                            petName = inputArgs[1];
                            clinicName = inputArgs[2];
                            this.finalResult.AppendLine(this.commandInterpreter.AddPetToClinic(petName, clinicName).ToString());
                            break;
                        case "Release":
                            clinicName = inputArgs[1];
                            this.finalResult.AppendLine(this.commandInterpreter.RealesePet(clinicName).ToString());
                            break;
                        case "HasEmptyRooms":
                            clinicName = inputArgs[1];
                            this.finalResult.AppendLine(this.commandInterpreter.HasEmptyRooms(clinicName).ToString());
                            break;
                        case "Print":
                            this.ProcessPrinit(inputArgs.Skip(1).ToArray());
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    this.finalResult.AppendLine(ex.Message);
                }
            }

            Console.WriteLine(this.finalResult.ToString().Trim());
        }

        private void ProcessPrinit(string[] inputArgs)
        {
            string clinicName = inputArgs[0];

            if (inputArgs.Length > 1)
            {
                int room = int.Parse(inputArgs[1]);
                this.finalResult.AppendLine(this.commandInterpreter.PrintRoom(clinicName, room));
            }
            else
            {
                this.finalResult.AppendLine(this.commandInterpreter.PrintAll(clinicName));
            }
        }

        private void ProcessCreation(string[] commandArgs)
        {
            string type = commandArgs[0];

            if (type == "Clinic")
            {
                try
                {
                    string clinicName = commandArgs[1];
                    int clinicRooms = int.Parse(commandArgs[2]);
                    this.commandInterpreter.CreateClinic(clinicName, clinicRooms);
                }
                catch (InvalidOperationException ex)
                {
                    this.finalResult.AppendLine(ex.Message);
                }
            }

            if (type == "Pet")
            {
                string petName = commandArgs[1];
                int age = int.Parse(commandArgs[2]);
                string petKind = commandArgs[3];
                this.commandInterpreter.CreatePet(petName, age, petKind);
            }
        }
    }
}

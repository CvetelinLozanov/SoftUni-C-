
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


    public class CommandInterpreter : ICommandInterpreter

    {
        public IExecutable InterpretCommand(string commandName, string[] data)
        {
            string name = commandName.ToUpper().First() + commandName.ToLower().Substring(1) + "Command";

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == name);

            IExecutable instance = (IExecutable)Activator.CreateInstance(type, new object[] { data });

            return instance;
        }
    }


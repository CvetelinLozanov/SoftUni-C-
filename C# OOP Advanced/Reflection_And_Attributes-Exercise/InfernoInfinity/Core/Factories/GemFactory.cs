

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string clarity, string gemType)
        {
            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == gemType);

            IGem instance = (IGem)Activator.CreateInstance(type, new object[] { gemClarity });

            return instance;


        }

    }


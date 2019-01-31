using Person.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Person.Core
{
    public class Engine
    {
        public void Run()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);                
            }      
        }
    }
}

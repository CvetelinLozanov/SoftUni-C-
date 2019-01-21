using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tire;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tire)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }   

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        } 

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }     
                
        public List<Tire> Tire
        {
            get { return tire; }
            set { tire = value; }
        }
    }
}

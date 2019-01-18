using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
       
        public string Weight
        {
            get => weight;
            set => weight = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }     

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}: ");
            sb.AppendLine($" {this.Engine.ToString()}");
            sb.AppendLine($" Weight: {this.Weight}");
            sb.AppendLine($" Color: {this.Color}");

            return sb.ToString().Trim();
        }
    }
}

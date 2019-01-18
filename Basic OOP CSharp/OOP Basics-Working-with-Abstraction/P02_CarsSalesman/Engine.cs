using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private string model;
        private string power;
        private string displacement;
        private string efficiency;

        public string Model
        {
            get => model;
            set => model = value;
        }

        public string Power
        {
            get => power;
            set => power = value;
        }

        public string Displacement
        {
            get => displacement;
            set => displacement = value;
        }

        public string Efficiency
        {
            get => efficiency;
            set => efficiency = value;
        }

        public Engine(string model, string power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {this.Displacement}");
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().Trim();
        }
    }

}

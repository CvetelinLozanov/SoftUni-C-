namespace Google
{
    public class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override string ToString()
        {
            return $"{this.Model} {Speed}";
        }
    }
}

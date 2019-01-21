namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string elemnet;
        private int health;

        public Pokemon(string name, string element)
        {
            this.Name = name;
            this.Element = element;
            this.Health = 0;
        }

        public Pokemon(string name, string element, int health) : this(name, element)
        {
            this.Health = health;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Element
        {
            get { return elemnet; }
            set { elemnet = value; }
        }
    }
}

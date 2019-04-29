namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T number)
        {
            this.Number = number;
        }

        public T Number { get; set; }

        public override string ToString()
        {
            return $"{this.Number.GetType().FullName}: {this.Number}";
        }
    }
}

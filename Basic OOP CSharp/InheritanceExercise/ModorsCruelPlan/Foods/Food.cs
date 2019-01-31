namespace ModorsCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int happiness)
        {
            this.Happiness = happiness;
        }

        public int Happiness { get; }
    }
}

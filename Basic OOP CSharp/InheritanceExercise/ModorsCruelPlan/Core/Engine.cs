using ModorsCruelPlan.Factories;
using ModorsCruelPlan.Foods;
using ModorsCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModorsCruelPlan.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;
        private List<Food> foods;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
            this.foods = new List<Food>();
        }

        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string type = input[i];
                Food food = foodFactory.CreateFood(type);
                foods.Add(food);
            }

            int points = foods.Sum(x => x.Happiness);
         
            Mood mood;

            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");          
            }
            else if (points >= -5 && points < 0)
            {
                mood = moodFactory.CreateMood("sad");               
            }
            else if (points > 0 && points < 15)
            {
                mood = moodFactory.CreateMood("happy");              
            }
            else 
            {
                mood = moodFactory.CreateMood("javascript");             
            }
            Console.WriteLine(points);
            Console.WriteLine(mood.GetType().Name);            
        }
    }
}

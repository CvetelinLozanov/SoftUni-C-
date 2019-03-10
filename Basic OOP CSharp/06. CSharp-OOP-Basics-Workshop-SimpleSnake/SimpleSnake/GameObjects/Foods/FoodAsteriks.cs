using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsteriks : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoints = 1;

        public FoodAsteriks(Wall wall)
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}

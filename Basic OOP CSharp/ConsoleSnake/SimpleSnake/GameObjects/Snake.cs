using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] food;
        private Obstacle obstacle;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake()
        {
            this.snakeElements = new Queue<Point>();
            this.food = new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.obstacle = new Obstacle();
            this.GetFood();
            this.CreateSnake();
        }

        public int RandomFoodNumber => new Random().Next(0, food.Length);

        public bool isMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();

            this.GetNextPosition(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(nextLeftX, nextTopY);

            if (newSnakeHead.LeftX == - 1)
            {
                newSnakeHead.LeftX = Console.WindowWidth - 1;
            }
            else if (newSnakeHead.LeftX == Console.WindowWidth)
            {
                newSnakeHead.LeftX = 0;
            }
            else if (newSnakeHead.TopY == - 1)
            {
                newSnakeHead.TopY = Console.WindowHeight - 1;
            }
            else if (newSnakeHead.TopY == Console.WindowHeight)
            {
                newSnakeHead.TopY = 0;
            }

            if (DateTime.Now.Millisecond % 90 == 0)
            {
                this.obstacle.SetRandomObstacle(snakeElements, direction);
            }

            if (this.obstacle.IsObstacle(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (this.food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }


            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPosition(direction, currentSnakeHead);
            }

          
            this.foodIndex = RandomFoodNumber;
            this.food[foodIndex].SetRandomFood(snakeElements, this.obstacle.Obstacles);


        }

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.food[foodIndex].SetRandomFood(snakeElements, this.obstacle.Obstacles);
        }

        private void GetFood()
        {
            this.food[0] = new FoodHash();
            this.food[1] = new FoodDollar();
            this.food[2] = new FoodAsteriks();
        }

        private void GetNextPosition(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }
    }
}

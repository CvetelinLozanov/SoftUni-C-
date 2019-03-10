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
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;


        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.food = new Food[3];
            this.foodIndex = RandomFoodNumber;
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

            if (this.wall.isPointOfWall(newSnakeHead))
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

            this.wall.AddPoints(this.snakeElements);
            this.wall.PlayerInfo();
            this.foodIndex = RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(snakeElements);


        }

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.food[foodIndex].SetRandomPosition(snakeElements);
        }

        private void GetFood()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsteriks(this.wall);
        }

        private void GetNextPosition(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }
    }
}

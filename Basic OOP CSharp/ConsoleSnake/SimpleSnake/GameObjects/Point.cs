using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;
        private Random random;

        public Point()
        {
            this.random = new Random();
        }

        public Point(int leftX, int topY)
            : this()
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return leftX;
            }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }
                leftX = value;
            }
        }

        public int TopY
        {
            get
            {
                return topY;
            }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }
                topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.leftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }

        public Point GetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, Console.WindowWidth - 2);
            this.TopY = random.Next(2, Console.WindowHeight - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, Console.WindowWidth - 2);
                this.TopY = random.Next(2, Console.WindowHeight - 2);

                isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }
            return new Point(this.LeftX, this.TopY);
        }
    }
}

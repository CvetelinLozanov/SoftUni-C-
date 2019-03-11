using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Obstacle : Point
    {
        private const char obstacleSymbol = '@';
        private List<Point> obstacles;

        public Obstacle()
        {
            this.obstacles = new List<Point>();
        }

        public bool IsObstacle(Point snakePoint)
        {
            return this.obstacles.Any(x => x.LeftX == snakePoint.LeftX
            && x.TopY == snakePoint.TopY);
        }

        public IReadOnlyCollection<Point> Obstacles
        {
            get { return this.obstacles.AsReadOnly(); }
            
        }

        public void SetRandomObstacle(Queue<Point> snakeElements, Point direction)
        {
            Point point = this.GetRandomPosition(snakeElements);
            
            Point snakeHead = snakeElements.Last();

            int nextLeftX = direction.LeftX + snakeHead.LeftX;
            int nextTopY = direction.TopY + snakeHead.TopY;

            bool isObstacle = point.LeftX == snakeHead.LeftX && point.TopY == nextTopY;

            while (isObstacle)
            {
                point = this.GetRandomPosition(snakeElements);

                nextLeftX = direction.LeftX + snakeHead.LeftX;
                nextTopY = direction.TopY + snakeHead.TopY;

                isObstacle = point.LeftX == snakeHead.LeftX && point.TopY == nextTopY;
            }            

            this.obstacles.Add(point);
            point.Draw(obstacleSymbol);
        }
    }
}

namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

          //  Wall wall = new Wall(60, 20);

            Snake snake = new Snake();

            Engine engine = new Engine(snake);
            engine.Run();
        }
    }
}

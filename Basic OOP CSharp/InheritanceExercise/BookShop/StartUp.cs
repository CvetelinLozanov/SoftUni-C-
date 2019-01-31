using BookShop.Core;
using System;

namespace BookShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}

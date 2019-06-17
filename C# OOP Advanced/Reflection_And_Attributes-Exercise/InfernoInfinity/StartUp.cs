﻿
using System;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            var repository = new WeaponRepository();
            var interpreter = new CommandInterpreter();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();
            IEngine engine = new Engine(gemFactory, weaponFactory, interpreter, repository);
            engine.Run();
        }
    }


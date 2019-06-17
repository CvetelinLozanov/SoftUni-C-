namespace P03_BarraksWars.Models.Units
{
    using _03BarracksFactory.Models.Units;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultAttack = 10;

        public Horseman() 
            : base(DefaultHealth, DefaultAttack)
        {
        }
    }
}

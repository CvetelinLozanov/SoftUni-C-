using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Colombian : Item
    {
        private const int ColumbianValue = 50000;

        public Colombian() 
            : base(ColumbianValue)
        {
        }
    }
}

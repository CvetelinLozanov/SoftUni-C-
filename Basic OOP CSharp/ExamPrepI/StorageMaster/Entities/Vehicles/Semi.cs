using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Semi : Vehicle
    {
        private const int SemiCapacity = 10;

        public Semi() 
            : base(SemiCapacity)
        {
        }
    }
}

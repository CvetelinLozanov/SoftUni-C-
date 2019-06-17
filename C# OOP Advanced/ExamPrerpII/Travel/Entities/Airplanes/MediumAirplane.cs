using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int MediumAirplaneSeats = 10;
        private const int MediumAirplaneBagageCompartments = 14;

        public MediumAirplane()
            : base(MediumAirplaneSeats, MediumAirplaneBagageCompartments)
        {
        }
    }
}

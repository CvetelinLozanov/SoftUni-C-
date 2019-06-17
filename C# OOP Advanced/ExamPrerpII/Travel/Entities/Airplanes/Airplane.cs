namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        protected Airplane(int seats, int bagageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = bagageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
       
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();


        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var baggage = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return baggage;
        }

        public void LoadBag(IBag bag)
        {
            if (this.BaggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            //if (seat < 0 || seat > passengers.Count - 1)
            //{
            //    throw new IndexOutOfRangeException();
            //}
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }
    }
}

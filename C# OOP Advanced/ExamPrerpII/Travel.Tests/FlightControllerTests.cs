// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
        private Airport airport;

        [SetUp]
        public void SetUp()
        {
            this.airport = new Airport();
        }

        [Test]
        public void CheckIfTripIsCompleted()
        {
            
            var airplane = new LightAirplane();
            Trip trip = new Trip("Tuk", "Tam", airplane);
            var passenger = new Passenger("Gosho");
            var bag = new Bag(passenger, new Item[] { new Toothbrush() });
            passenger.Bags.Add(bag);
            airport.AddTrip(trip);

            trip.Complete();

            var flightController = new FlightController(airport);

            var expectedResult = flightController.TakeOff();
            var actualResult = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfAirplaneIsOverbookd()
        {
         
            var airplane = new LightAirplane();
            Trip trip = new Trip("Tuk", "Tam", airplane);

            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                airplane.AddPassenger(passengers[i]);

            }

            airport.AddTrip(trip);

            var flightController = new FlightController(airport);

            var expectedResult = flightController.TakeOff();
            var actualResult = "TukTam2:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestLoadCarryOnBaggage()
        {
          
            var airplane = new LightAirplane();
            Trip trip = new Trip("Tuk", "Tam", airplane);

            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                airplane.AddPassenger(passengers[i]);

            }

            airport.AddTrip(trip);

            FlightController flightController = new FlightController(airport);

            var completedTrip = new Trip("Tam", "Tuk", new MediumAirplane());
            completedTrip.Complete();
            airport.AddTrip(completedTrip);

            var actualResult = flightController.TakeOff();
            var expexctedResult = "TukTam3:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expexctedResult, actualResult);
            Assert.AreEqual(trip.IsCompleted, true);

        }
    }
}

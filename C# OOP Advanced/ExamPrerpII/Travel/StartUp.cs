﻿namespace Travel
{
    using Core;
    using Core.Controllers;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;

   
    public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();			
			IWriter writer = new ConsoleWriter();

			IAirport airport = new Airport();
			var airportController = new AirportController(airport);
			var flightController = new FlightController(airport);

			var engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}
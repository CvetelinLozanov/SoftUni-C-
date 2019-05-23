namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string airplaneType)
		{
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == airplaneType);

            IAirplane airplane = (IAirplane)Activator.CreateInstance(type);

            return airplane;
		}
	}
}
namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
	using System;
	using System.Reflection;
	using System.Linq;

	public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string planeType)
		{
			Type type = Assembly.GetCallingAssembly().GetTypes().First(p => p.Name == planeType);
			IAirplane plane = (IAirplane)Activator.CreateInstance(type);

			return plane;
		}
	}
}
namespace Travel
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Airplanes;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			//IReader reader = new ConsoleReader();
			//IWriter writer = new ConsoleWriter();

			//IAirport airport = new Airport();
			//IAirportController airportController = new AirportController(airport);
			//IFlightController flightController = new FlightController(airport);

			//IEngine engine = new Engine(reader, writer, airportController, flightController);
			//engine.Run();

			int i = 10;
			int j = 1;
			do
			{
				j++;
				if (j > i)
					break;
				--i;
			}
			while (j < i);

			System.Console.WriteLine("i = " + i + "j = " + j);
		}
	}
}
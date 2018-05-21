// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Travel.Core.Controllers;
	using Travel.Core.Controllers.Contracts;
	using Travel.Entities;
	using Travel.Entities.Airplanes;
	using Travel.Entities.Airplanes.Contracts;
	using Travel.Entities.Contracts;
	using Travel.Entities.Items;
	using Travel.Entities.Items.Contracts;

	[TestFixture]
	public class FlightControllerTests
	{
		[Test]
		public void FlightControllerSuccessfullFlightWithNoConfiscatedBags()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IPassenger passenger = new Passenger("Pesho");
			IItem[] items = new IItem[] { new CellPhone(), new Jewelery() };
			IBag bag = new Bag(passenger, items);

			passenger.Bags.Add(bag);
			airport.AddPassenger(passenger);
			airport.AddTrip(trip);
			trip.Airplane.AddPassenger(passenger);

			string id = trip.Id;

			string actualMessage = flightController.TakeOff();
			string expectedMessage = $"{id}:" + Environment.NewLine +
									"Successfully transported 1 passengers from Sofia to Varna." + Environment.NewLine +
									"Confiscated bags: 0 (0 items) => $0";

			Assert.That(actualMessage, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void FlightControllerEjectPassanger()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IList<IPassenger> passengers = new List<IPassenger>();
			for (int index = 0; index < 6; index++)
			{
				IPassenger passenger = new Passenger($"Pesho{index}");
				passengers.Add(passenger);
			}

			IItem[] items = new IItem[] { new CellPhone(), new Jewelery() };
			IBag bag = new Bag(passengers[1], items);

			passengers[1].Bags.Add(bag);
			for (int i = 0; i < 6; i++)
			{
				airport.AddPassenger(passengers[i]);
			}
			airport.AddTrip(trip);
			for (int i = 0; i < 6; i++)
			{
				trip.Airplane.AddPassenger(passengers[i]);
			}

			string id = trip.Id;

			string actualMessage = flightController.TakeOff();
			string expectedMessage = $"{id}:" + Environment.NewLine +
									"Overbooked! Ejected Pesho1" + Environment.NewLine +
									"Confiscated 1 bags ($1000)" + Environment.NewLine +
									"Successfully transported 5 passengers from Sofia to Varna." + Environment.NewLine +
									"Confiscated bags: 1 (2 items) => $1000";

			Assert.That(actualMessage, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void IsTripCompleted()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IPassenger passenger = new Passenger("Pesho");
			IItem[] items = new IItem[] { new CellPhone(), new Jewelery() };
			IBag bag = new Bag(passenger, items);

			passenger.Bags.Add(bag);
			airport.AddPassenger(passenger);
			airport.AddTrip(trip);
			trip.Airplane.AddPassenger(passenger);

			flightController.TakeOff();

			bool isTripCompleted = trip.IsCompleted;

			Assert.That(isTripCompleted, Is.EqualTo(true));
		}

		[Test]
		public void LuggageLoadedSuccessfully()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IPassenger passenger = new Passenger("Pesho");
			IItem[] items = new IItem[] { new CellPhone(), new Jewelery() };
			IBag bag = new Bag(passenger, items);

			passenger.Bags.Add(bag);
			airport.AddPassenger(passenger);
			airport.AddTrip(trip);
			trip.Airplane.AddPassenger(passenger);

			flightController.TakeOff();

			IReadOnlyCollection<IBag> luggageOnPlane = plane.BaggageCompartment;
			IReadOnlyCollection<IBag> expectedLuggageOnPlane = new List<IBag>() { bag };

			Assert.That(luggageOnPlane, Is.EquivalentTo(expectedLuggageOnPlane));
		}

		[Test]
		public void LoadLuggageThrowsException()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IPassenger passenger = new Passenger($"Pesho");

			IList<IBag> bags = new List<IBag>();
			for (int i = 0; i < 9; i++)
			{
				IItem[] items = new IItem[] { new CellPhone(), new Jewelery() };
				bags.Add(new Bag(passenger, items));
			}

			for (int i = 0; i < 9; i++)
			{
				passenger.Bags.Add(bags[i]);
			}

			FieldInfo[] bagsIfno = plane.GetType().BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo field = bagsIfno.FirstOrDefault(f => f.FieldType == typeof(List<IBag>));
			field.SetValue(plane, bags);

			airport.AddPassenger(passenger);
			airport.AddTrip(trip);
			trip.Airplane.AddPassenger(passenger);

			string id = trip.Id;

			Assert.That(() => flightController.TakeOff(), Throws.InvalidOperationException);
		}

		[Test]
		public void NoFlightsDepartured()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			string actualMessage = flightController.TakeOff();
			string expectedMessage = "Confiscated bags: 0 (0 items) => $0";

			Assert.That(actualMessage, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void ConfiscatedBagsValid()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			IPassenger passenger = new Passenger("Pesho");

			IBag bag = new Bag(passenger, new IItem[] { new CellPhone(), new Jewelery() });
			IBag bag2 = new Bag(passenger, new IItem[] { new Laptop() });
				
			airport.AddConfiscatedBag(bag);
			airport.AddConfiscatedBag(bag2);

			IReadOnlyCollection<IBag> expectedBags = new IBag[] { bag, bag2 };
			IReadOnlyCollection<IBag> actualBags = airport.ConfiscatedBags;

			Assert.That(expectedBags, Is.EquivalentTo(actualBags));
		}

		[Test]
		public void TripIsIncompleted()
		{
			IAirport airport = new Airport();
			IFlightController flightController = new FlightController(airport);

			IAirplane plane = new LightAirplane();
			ITrip trip = new Trip("Sofia", "Varna", plane);

			bool isTripCompleted = trip.IsCompleted;

			Assert.That(isTripCompleted, Is.EqualTo(false));
		}
	}
}

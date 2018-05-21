﻿namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IPassenger> passengers;
		private List<ITrip> trips;
		private List<IBag> confiscatedBags;
		private List<IBag> checkedInBags;

		public Airport()
		{
			this.passengers = new List<IPassenger>();
			this.trips = new List<ITrip>();
			this.confiscatedBags = new List<IBag>();
			this.checkedInBags = new List<IBag>();
		}

		public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags;

		public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags;

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

		public IReadOnlyCollection<ITrip> Trips => this.trips;

		public IPassenger GetPassenger(string username)
		{
			return this.passengers.FirstOrDefault(p => p.Username == username);
		}

		public ITrip GetTrip(string id)
		{
			return this.trips.FirstOrDefault(t => t.Id == id);
		}

		public void AddPassenger(IPassenger passenger)
		{
			this.passengers.Add(passenger);
		}

		public void AddTrip(ITrip trip)
		{
			this.trips.Add(trip);
		}

		public void AddCheckedBag(IBag bag)
		{
			this.checkedInBags.Add(bag);
		}

		public void AddConfiscatedBag(IBag bag)
		{
			this.confiscatedBags.Add(bag);
		}
	}
}
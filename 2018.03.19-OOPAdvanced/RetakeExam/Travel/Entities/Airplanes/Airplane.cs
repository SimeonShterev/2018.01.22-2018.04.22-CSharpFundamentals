using System;
using System.Collections.Generic;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
	public abstract class Airplane : IAirplane
	{
		private List<IPassenger> passengers;
		private List<IBag> bags;

		protected Airplane(int seats, int bags)
		{
			this.Seats = seats;
			this.BaggageCompartments = bags;

			this.passengers = new List<IPassenger>();
			this.bags = new List<IBag>();
		}

		public int Seats { get; }

		public int BaggageCompartments { get; }

		public IReadOnlyCollection<IBag> BaggageCompartment => this.bags;

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

		public bool IsOverbooked => this.Passengers.Count > this.Seats ? true : false;

		public void AddPassenger(IPassenger passenger)
		{
			this.passengers.Add(passenger);
		}

		//public IEnumerable<IBag> Out(IPassenger passenger)
		//{
		//	var passengerBags = this.bagazhi
		//		.Where(b => b.Owner == passenger)
		//		.ToArray();

		//	foreach (var bag in passengerBags)
		//		this.bagazhi.Remove(bag);

		//	return passengerBags;
		//}
		public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
		{
			IList<IBag> removedBags = new List<IBag>();

			foreach (var bag in bags)
			{
				if (bag.Owner == passenger)
				{
					removedBags.Add(bag);
				}
			}
			foreach (var bagToRemove in removedBags)
			{
				this.bags.Remove(bagToRemove);
			}

			return removedBags;
		}

		public void LoadBag(IBag bag)
		{
			bool isBaggageCompartmentFull = this.BaggageCompartment.Count >= this.BaggageCompartments;
			if (isBaggageCompartmentFull)
			{
				throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");
			}

			this.bags.Add(bag);
		}

		public IPassenger RemovePassenger(int seat)
		{
			IPassenger passenger = this.passengers[seat];
			this.passengers.RemoveAt(seat);

			return passenger;
		}
	}
}

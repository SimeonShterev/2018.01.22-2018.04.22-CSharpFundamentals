using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
	private const double TankCapacity = 160d;

	private double fuelAmount;

	public Car(int hp, double fuelAmount, Tyre tyre)
	{
		this.Hp = hp;
		this.FuelAmount = fuelAmount;
		this.Tyre = tyre;
	}

	public int Hp { get; }

	public Tyre Tyre { get; private set; }

	public double FuelAmount
	{
		get
		{
			return this.fuelAmount;
		}
		protected set
		{
			if(value<0)
			{
				throw new ArgumentException(FailMessages.OutOfFuel);
			}
			if (value > TankCapacity)
			{
				this.fuelAmount = TankCapacity;
			}
			else
			{
				this.fuelAmount = value;
			}
		}
	}

	public void Refuel(double fuelAmount)
	{
		this.FuelAmount += fuelAmount;
	}

	public void ReduceFuelAmount(Track track, double fuelConsumptionPerKm)
	{
		this.FuelAmount -= track.TrackLength * fuelConsumptionPerKm;
	}
}
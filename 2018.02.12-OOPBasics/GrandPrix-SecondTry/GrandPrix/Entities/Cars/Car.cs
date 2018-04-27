using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
	private const double MaximumCapacity = 160;

	private double fuelAmount;

	public Car(int hp, double fuelAmount, Tyre tyre)
	{
		this.Hp = hp;
		this.FuelAmount = fuelAmount;
		this.Tyre = tyre;

	}

	public int Hp { get; }

	public double FuelAmount
	{
		get
		{
			return this.fuelAmount;
		}
		private set
		{
			if(value<0)
			{
				throw new InvalidOperationException(Consts.OutOfFuel);
			}
			this.fuelAmount = Math.Min(value, MaximumCapacity);
		}
	}

	public Tyre Tyre { get; }

	public void ReduceFuelAmount(int trackLength, double fuelConsumptionPerKm)
	{
		this.FuelAmount -= trackLength * fuelConsumptionPerKm;
	}
}
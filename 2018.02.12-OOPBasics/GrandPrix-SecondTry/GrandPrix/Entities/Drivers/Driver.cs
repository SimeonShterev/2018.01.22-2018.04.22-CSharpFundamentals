using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
	protected Driver(string name, Car car)
	{
		this.Name = name;
		this.Car = car;
		this.TotalTime = 0d;
	}

	public string Name { get; }

	public double TotalTime { get; private set; }

	public Car Car { get; }

	public abstract double FuelConsumptionPerKm { get; }

	public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

	public void CompleteLaps(int trackLength)
	{
		this.Car.ReduceFuelAmount(trackLength, this.FuelConsumptionPerKm);
		this.Car.Tyre.CompleteLap();

		this.TotalTime += 60 / trackLength / this.Speed;
	}
}
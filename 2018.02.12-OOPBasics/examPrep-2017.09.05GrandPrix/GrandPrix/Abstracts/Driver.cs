using System;
using System.Collections.Generic;
using System.Text;

public abstract class Driver
{
	private const int BoxTime = 20; 

	public Driver(string driverType, string name, Car car)
	{
		this.Name = name;
		this.Car = car;
		this.Type = driverType;
	}

	public string Type { get; }

	public string Name { get; }

	public double TotalTime { get; private set; }

	public Car Car { get; private set; }

	public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

	public abstract double FuelConsumptionPerKm { get; }

	public string FailureReason { get; private set; }

	public void ChangeTotalTime(Track track)
	{
		this.TotalTime += 60 / (track.TrackLength / this.Speed);
	}

	public void Overtake(int time, Driver overtakenDriver)
	{
		this.TotalTime -= time;
		overtakenDriver.TotalTime += time;
	}

	public void Box(string reason, double secondParameter, double grip=0)
	{
		this.TotalTime += 20;
		if(reason== "Refuel")
		{
			Refuel(secondParameter);
		}
		else
		{
			ChangeTyre(secondParameter, grip);
		}
	}

	private void Refuel(double fuelAmount)
	{
		this.Car.Refuel(fuelAmount);
	}

	private void ChangeTyre(double tyreHardness, double grip=0)
	{
		this.Car.Tyre.ChangeTyres(tyreHardness, grip);
	}

	public void Fail(string message)
	{
		this.FailureReason = message;
	}

	public  string AnnounceWinner()
	{
		string result = $"{this.Name} wins the race for {this.TotalTime:f3} seconds.";
		return result;
	}
	public override string ToString()
	{
		string result = $"{this.Name} {this.FailureReason}";
		return result;
	}
}
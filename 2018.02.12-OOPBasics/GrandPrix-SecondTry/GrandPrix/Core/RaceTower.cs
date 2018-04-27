using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
	private int lapsNumber;
	private int trackLength;
	private int currentLap;

	private List<Driver> drivers;


	public RaceTower()
	{

	}

	public void SetTrackInfo(int lapsNumber, int trackLength)
	{
		this.lapsNumber = lapsNumber;
		this.trackLength = trackLength;
	}
	public void RegisterDriver(List<string> commandArgs)
	{
		Tyre tyre = CreateTyre(commandArgs.Skip(4).ToList());

		int hp = int.Parse(commandArgs[2]);
		double fuelAmount = double.Parse(commandArgs[3]);
		Car car = new Car(hp, fuelAmount, tyre);

		string type = commandArgs[0];
		string name = commandArgs[1];
		Driver driver = CreateDriver(type, name, car);

		if (driver != null)
		{
			this.drivers.Add(driver);
		}
	}

	public void DriverBoxes(List<string> commandArgs)
	{
		//TODO: Add some logic here …
	}

	public string CompleteLaps(List<string> commandArgs)
	{
		int laps = int.Parse(commandArgs[0]);
		for (int lap = 0; lap < laps; lap++)
		{
			foreach (var driver in this.drivers)
			{
				driver.CompleteLaps(this.trackLength);
			}
		}
		return null;
	}

	public string GetLeaderboard()
	{
		throw new NotImplementedException();
	}

	public void ChangeWeather(List<string> commandArgs)
	{
		//TODO: Add some logic here …
	}

	private Tyre CreateTyre(List<string> tyreArgs)
	{
		string type = tyreArgs[0];
		double hardness = double.Parse(tyreArgs[1]);

		Tyre tyre = null;
		if (type == "Hard")
		{
			tyre = new HardTyre(hardness);
		}
		else if (type == "Ultrasoft")
		{
			double grip = double.Parse(tyreArgs[2]);
			tyre = new UltrasoftTyre(hardness, grip);
		}
		return tyre;
	}

	private Driver CreateDriver(string type, string name, Car car)
	{
		Driver driver = null;
		if (type == "Aggressive")
		{
			driver = new AggressiveDriver(name, car);
		}
		else if (type == "Endurance")
		{
			driver = new EnduranceDriver(name, car);
		}
		return driver;
	}
}
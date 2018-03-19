using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
	private DriverFactory driverFactory;
	private TyreFactory tyreFactory;

	private List<Driver> driversList;
	private Stack<string> failedDrivers;
	private Track track;

	public Driver winner;
	public bool isRaceOver;

	public RaceTower()
	{
		this.tyreFactory = new TyreFactory();
		this.driverFactory = new DriverFactory();
		this.driversList = new List<Driver>();
		this.failedDrivers = new Stack<string>();
	}

	public void SetTrackInfo(int lapsNumber, int trackLength)
	{
		this.track = new Track(lapsNumber, trackLength);
	}

	public void RegisterDriver(List<string> commandArgs)
	{
		Tyre tyre = tyreFactory.CreateTyre(commandArgs);
		Driver driver = driverFactory.CreateDriver(commandArgs, tyre);
		driversList.Add(driver);
	}

	public void DriverBoxes(List<string> commandArgs)
	{
		string updateOperation = commandArgs[0];
		string driverName = commandArgs[1];
		Driver driver = driversList.Find(dr => dr.Name == driverName);
		switch (updateOperation)
		{
			case "Refuel":
				double fuelAmount = double.Parse(commandArgs[2]);
				driver.Box(updateOperation, fuelAmount);
				break;
			case "ChangeTyre":
				string tyreType = commandArgs[2];
				double tyreHardness = double.Parse(commandArgs[3]);
				switch (tyreType)
				{
					case "Hard":
						driver.Box(updateOperation, tyreHardness);
						break;
					case "Ultrasoft":
						double grip = double.Parse(commandArgs[4]);
						driver.Box(updateOperation, tyreHardness, grip);
						break;
				}
				break;
		}
	}

	public string CompleteLaps(List<string> commandArgs)
	{
		int numberOfLaps = int.Parse(commandArgs[0]);
		StringBuilder sb = new StringBuilder();
		if (numberOfLaps + track.CurrentLap > track.LapsNum)
		{
			return $"There is no time! On lap {track.CurrentLap}.";
		}

		for (int lap = 1; lap <= numberOfLaps; lap++)
		{
			this.track.CurrentLap++;
			for (int index = 0; index < driversList.Count; index++)
			{
				driversList[index].ChangeTotalTime(this.track);
				try
				{
					driversList[index].Car.ReduceFuelAmount(track, driversList[index].FuelConsumptionPerKm);
					driversList[index].Car.Tyre.ReduceDegradation();
				}
				catch (ArgumentException ex)
				{
					driversList[index].Fail(ex.Message);
					this.failedDrivers.Push(driversList[index].ToString());
					driversList.Remove(driversList[index]);
					index--;
				}
			}

			List<Driver> sortedDrivers = this.driversList
				.OrderByDescending(d => d.TotalTime)
				.ToList();

			for (int index = 0; index < sortedDrivers.Count - 1; index++)
			{
				Driver overtakingDriver = sortedDrivers[index];
				Driver targetDriver = sortedDrivers[index + 1];

				double intervalOfTimeBetweenDrivers = overtakingDriver.TotalTime - targetDriver.TotalTime;

				bool enduranceDriver = overtakingDriver.Type == "Endurance" && overtakingDriver.Car.Tyre.Name == "Hard" && track.WeatherNow == Weather.Rainy;

				bool aggressiveDriver = overtakingDriver.Type == "Aggressive" && overtakingDriver.Car.Tyre.Name == "Ultrasoft" && track.WeatherNow == Weather.Foggy;

				if (intervalOfTimeBetweenDrivers < 3)
				{
					if (aggressiveDriver || enduranceDriver)
					{
						overtakingDriver.Fail(FailMessages.Crashed);
						this.failedDrivers.Push(overtakingDriver.ToString());
						driversList.Remove(overtakingDriver);
					}
					else if (intervalOfTimeBetweenDrivers < 2)
					{
						overtakingDriver.Overtake(2, targetDriver);
						sb.AppendLine($"{overtakingDriver.Name} has overtaken {targetDriver.Name} on lap {track.CurrentLap}.");
						index++;
					}
				}
			}
			if (track.CurrentLap == track.LapsNum)
			{
				this.isRaceOver = true;
				this.winner = sortedDrivers.Last();
			}
		}
		return sb.ToString().TrimEnd();
	}

	public string GetLeaderboard()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Lap {track.CurrentLap}/{track.LapsNum}");
		int position = 1;
		foreach (var driver in driversList.OrderBy(dr => dr.TotalTime))
		{
			sb.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
			position++;
		}
		if (failedDrivers.Count != 0)
		{
			string[] allFailedDrivers = new string[failedDrivers.Count];
			failedDrivers.CopyTo(allFailedDrivers, 0);
			foreach (var failedDriver in allFailedDrivers)
			{
				sb.AppendLine($"{position} {failedDriver}");
				position++;
			}
		}
		return sb.ToString().TrimEnd();
	}

	public void ChangeWeather(List<string> commandArgs)
	{

		bool isValid = Enum.TryParse(typeof(Weather), commandArgs[0], out object currentWeather);
		if (isValid)
		{
			track.WeatherNow = (Weather)currentWeather;
		}
	}
}
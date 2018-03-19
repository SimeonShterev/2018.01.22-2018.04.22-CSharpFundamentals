using System;
using System.Collections.Generic;
using System.Text;

public class DriverFactory
{
	public Driver CreateDriver(List<string> commandArgs, Tyre tyre)
	{
		string type = commandArgs[0];
		string name = commandArgs[1];
		int hp = int.Parse(commandArgs[2]);
		double fuelAmount = double.Parse(commandArgs[3]);
		Car car = new Car(hp, fuelAmount, tyre);
		switch(type)
		{
			case "Aggressive":
				return new AggressiveDriver(type, name, car);
			case "Endurance":
				return new EnduranceDriver(type, name, car);
			default:
				throw new ArgumentException(FailMessages.NotSuchDriver);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;

public class EnduranceDriver : Driver
{
	public EnduranceDriver(string type, string name, Car car)
		: base("Endurance", name, car) { }

	public override double FuelConsumptionPerKm => 1.5;
}
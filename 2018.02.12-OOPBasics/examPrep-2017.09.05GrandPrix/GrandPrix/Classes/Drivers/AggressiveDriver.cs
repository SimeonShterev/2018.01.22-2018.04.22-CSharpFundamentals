using System;
using System.Collections.Generic;
using System.Text;

public class AggressiveDriver : Driver
{

	public AggressiveDriver(string type, string name, Car car)
		: base("Aggresive", name, car) { }

	public override double Speed => base.Speed * 1.3;

	public override double FuelConsumptionPerKm => 2.7;
}
using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
	private Signals signal;

	public TrafficLight(string signal)
	{
		this.Signal = signal;
	}

	public string Signal
	{
		get
		{
			return this.signal.ToString();
		}
		set
		{
			this.signal = Enum.Parse<Signals>(value);
		}
	}

	public void ChangeTrafficLightSignal()
	{
		var enumArr = typeof(Signals).GetEnumValues();
		this.signal = (Signals)enumArr.GetValue((int)(this.signal + 1) % enumArr.Length);
	}

	public override string ToString()
	{
		return this.signal.ToString();
	}
}

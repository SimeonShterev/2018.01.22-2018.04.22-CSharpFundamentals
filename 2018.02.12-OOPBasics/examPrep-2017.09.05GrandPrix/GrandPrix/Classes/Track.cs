using System;
using System.Collections.Generic;
using System.Text;

public class Track
{
	private int currentLap;

	public Track(int lapNum, int trackLegth)
	{
		this.LapsNum = lapNum;
		this.TrackLength = trackLegth;
		this.WeatherNow = Weather.Sunny;
		this.CurrentLap = 0;
	}

	public Weather WeatherNow { get; set; }

	public int LapsNum { get; }

	public int TrackLength { get; }

	public int CurrentLap
	{
		get
		{
			return this.currentLap;
		}
		set
		{
			if(value>this.LapsNum)
			{
				throw new ArgumentException(string.Format(FailMessages.TooMuchLaps, this.currentLap));
			}
			this.currentLap = value;
		}
	}
}
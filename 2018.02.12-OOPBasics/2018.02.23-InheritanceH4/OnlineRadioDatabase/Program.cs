using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		List<Radio> songList = new List<Radio>();
		TimeSpan timeCounter = new TimeSpan(0, 0, 0);
		int lines = int.Parse(Console.ReadLine());
		for (int i = 0; i < lines; i++)
		{
			try
			{
				string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
				if (input.Length != 3)
					throw new InvalidSongException();
				string artistName = input[0];
				string songName = input[1];
				string songLenght = input[2];
				Radio radio = new Radio(artistName, songName, songLenght);
				timeCounter = AddTime(timeCounter, radio);
				songList.Add(radio);
				Console.WriteLine("Song added.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		int songsCount = songList.Count;
		Console.WriteLine($"Songs added: {songsCount}");
		int hoursResult = timeCounter.Hours;
		int minutesResult = timeCounter.Minutes;
		int secondsResult = timeCounter.Seconds;
		Console.WriteLine($"Playlist length: {hoursResult}h {minutesResult}m {secondsResult}s");
	}

	private static TimeSpan AddTime(TimeSpan timeCounter, Radio radio)
	{
		int minutes = radio.Minutes;
		int seconds = radio.Seconds;
		TimeSpan currentSongLenght = new TimeSpan(0, minutes, seconds);
		timeCounter += currentSongLenght;
		return timeCounter;
	}
}
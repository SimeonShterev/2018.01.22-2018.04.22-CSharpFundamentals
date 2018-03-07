using System;
using System.Collections.Generic;

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
				string[] input;
				string artistName;
				string songName;
				string[] songLenght;
				int minutes;
				int seconds;
				try
				{
					input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
					artistName = input[0];
					songName = input[1];
					try
					{
						songLenght = input[2].Split(':');
						minutes = int.Parse(songLenght[0]);
						seconds = int.Parse(songLenght[1]);
					}
					catch (Exception)
					{
						Console.WriteLine("Invalid song length.");
						continue;
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Invalid song.");
					continue;
				}
				Radio radio = new Radio(artistName, songName, minutes, seconds);
				TimeSpan currentSongLenght = new TimeSpan(0, minutes, seconds);
				timeCounter = timeCounter.Add(currentSongLenght);
				songList.Add(radio);
				Console.WriteLine("Song added.");
			}
			catch (ArgumentException ex)
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
}
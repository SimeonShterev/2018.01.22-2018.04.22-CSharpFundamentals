using System;
using System.Collections.Generic;
using System.Text;

public class Radio : IRadio
{
    private string artistName;
    private string songName;
	private string lenght;
    private int minutes;
    private int seconds;

    public Radio(string artistName, string songName, string lenght)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
		this.Lenght = lenght;
    }

	public string Lenght {
		get
		{
			return this.lenght;
		}
		set
		{
			string[] timeTokens = value.Split(':', StringSplitOptions.RemoveEmptyEntries);
			if (timeTokens.Length != 2)
				throw new InvalidSongLenghtException();
			bool minuteParse = int.TryParse(timeTokens[0], out int minutes);
			bool secondsParse = int.TryParse(timeTokens[1], out int seconds);
			if (!minuteParse || !secondsParse)
				throw new InvalidSongLenghtException();
			else
			{
				this.Minutes = minutes;
				this.Seconds = seconds;
			}
			this.lenght = value;
		}
	} 

	public int Seconds
    {
        get { return this.seconds; }
        set
        {
			if (value < 0 || value > 59)
				throw new InvalidSongSecondsException();
            this.seconds = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
			if (value < 0 || value > 14)
				throw new InvalidSongMinutesException();
            this.minutes = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
			if (value.Length < 3 || value.Length > 30)
				throw new InvalidSongLenghtException();
            this.songName = value;
        }
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
			if (value.Length < 3 || value.Length > 20)
				throw new InvalidArtistNameException();
            this.artistName = value;
        }
    }
}
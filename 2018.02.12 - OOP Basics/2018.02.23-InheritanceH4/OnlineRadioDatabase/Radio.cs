using System;
using System.Collections.Generic;
using System.Text;

public class Radio : IRadio
{
    private const string InvalidSongEx = "Invalid song.";
    private const string InvalidArtistNameEx = "Artist name should be between 3 and 20 symbols.";
    private const string InvalidSongNameEx = "Song name should be between 3 and 30 symbols.";
    private const string InvalidSongLenghtEx = "Invalid song length.";
    private const string InvalidSongMinutesEx = "Song minutes should be between 0 and 14.";
    private const string InvalidSongSecondssEx = "Song seconds should be between 0 and 59.";

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Radio(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < 0 || value > 59)
                throw new ArgumentException(InvalidSongSecondssEx);
            this.seconds = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (value < 0 || value > 14)
                throw new ArgumentException(InvalidSongMinutesEx);
            this.minutes = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new ArgumentException(InvalidSongNameEx);
            this.songName = value;
        }
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new ArgumentException(InvalidArtistNameEx);
            this.artistName = value;
        }
    }
}
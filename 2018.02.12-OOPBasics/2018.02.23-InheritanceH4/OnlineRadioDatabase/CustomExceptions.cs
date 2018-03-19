using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException : Exception
{
	public override string Message => "Invalid song.";
}

public class InvalidArtistNameException : Exception
{
	public override string Message => "Artist name should be between 3 and 20 symbols.";
}

public class InvaliSongNameException : Exception
{
	public override string Message => "Song name should be between 3 and 30 symbols.";
}

public class InvalidSongLenghtException : Exception
{
	public override string Message => "Invalid song length.";
}

public class InvalidSongMinutesException : Exception
{
	public override string Message => "Song minutes should be between 0 and 14.";
}

public class InvalidSongSecondsException : Exception
{
	public override string Message => "Song seconds should be between 0 and 59.";
}
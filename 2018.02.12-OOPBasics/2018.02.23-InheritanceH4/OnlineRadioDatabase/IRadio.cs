using System;
using System.Collections.Generic;
using System.Text;

public interface IRadio
{
    string ArtistName { get; set; }

    string SongName { get; set; }

    int Minutes { get; set; }

    int Seconds { get; set; }
}
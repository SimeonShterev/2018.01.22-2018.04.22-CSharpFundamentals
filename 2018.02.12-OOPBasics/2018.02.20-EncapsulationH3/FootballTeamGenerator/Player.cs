using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private double overallStats;

    public Player(string name, double overallStats)
    {
       this.Name = name;
        this.overallStats = overallStats;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public double GetStats
    {
        get { return this.overallStats; }
    }
}

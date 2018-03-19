using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private int power;

    public Engine(int power)
    {
        this.power = power;
    }

    public int Power
    {
        get { return this.power; }
        set
        {
            this.power = value;
        }
    }

}
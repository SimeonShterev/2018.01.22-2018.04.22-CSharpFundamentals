using System;
using System.Collections.Generic;
using System.Text;

public class Tire
{
    private double pressure;

    public Tire(double pressure)
    {
        this.Pressure = pressure;
    }

    public double Pressure
    {
        get { return this.pressure; }
        set
        {
                this.pressure = value;
        }
    }

    public void AddTire(List<Tire> tireList, Tire tire)
    {
        if(this.pressure<1)
        {
            tireList.Add(tire);
        }
    }
}

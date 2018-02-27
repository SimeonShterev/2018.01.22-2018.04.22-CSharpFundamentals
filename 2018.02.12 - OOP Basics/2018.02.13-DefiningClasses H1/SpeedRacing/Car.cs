using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private double fuel;
    private double consumption;
    private int distance = 0;
    
    public Car(string model, double fuel, double consumption)
    {
        this.model = model;
        this.fuel = fuel;
        this.consumption = consumption;
    }

    public int Distance
    {
        get
        {
            return this.distance;
        }
        set
        {
            this.distance = value;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }
    public double Fuel
    {
        get
        {
            return this.fuel;
        }
        set
        {
            this.fuel = value;
        }
    }
    public double Consumption
    {
        get
        {
            return this.consumption;
        }
        set
        {
            this.consumption = value;
        }
    }
    public Car CarOperation(Car car, string model, int distance)
    {
        bool cond = car.fuel >= car.consumption * distance;
        if(cond)
        {
            car.fuel -= car.consumption * distance;
            car.distance += distance;
            return car;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return car;
        }
    }
}

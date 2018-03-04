using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vechicle
{
    private double fuelQuantity;

    public Vechicle(double fuelQuantity, double tankCapacity, double fuelConsumption)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if(value>this.TankCapacity)
            {
                value = 0;
            }
            this.fuelQuantity = value;
        }
    }

    public double TankCapacity { get; set; }

    public double FuelConsumption { get; set; }

    public void Refueling(double refuelQuantity, bool isTruck = false)
    {
        if (this.fuelQuantity + refuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {refuelQuantity} fuel in the tank");
        }
        if (refuelQuantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (isTruck)
        {
            refuelQuantity = refuelQuantity * 95 / 100;
        }
        FuelQuantity += refuelQuantity;
    }

    public abstract string Drive(double kmToDrive);
}
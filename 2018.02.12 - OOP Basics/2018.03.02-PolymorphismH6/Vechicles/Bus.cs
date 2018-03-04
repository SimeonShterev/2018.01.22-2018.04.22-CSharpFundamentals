using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vechicle
{
    public Bus(double fuelQuantity,double tankCapacity,double fuelConsumption)
        : base(fuelQuantity,tankCapacity, fuelConsumption) { }

    public override string Drive(double kmToDrive)
    {

        double fuelNeeded = kmToDrive * (FuelConsumption + 1.4);
        bool isAbleToDrive = (FuelQuantity - fuelNeeded) >= 0;
        string result;
        if (isAbleToDrive)
        {
            result = $"Bus travelled {kmToDrive} km";
            FuelQuantity -= fuelNeeded;
        }
        else
        {
            result = "Bus needs refueling";
        }
        return result;
    }

    public string DriveEmpty(double kmToDrive)
    {

        double fuelNeeded = kmToDrive * FuelConsumption;
        bool isAbleToDrive = (FuelQuantity - fuelNeeded) > 0;
        string result;
        if (isAbleToDrive)
        {
            result = $"Bus travelled {kmToDrive} km";
            FuelQuantity -= fuelNeeded;
        }
        else
        {
            result = "Bus needs refueling";
        }
        return result;
    }
}
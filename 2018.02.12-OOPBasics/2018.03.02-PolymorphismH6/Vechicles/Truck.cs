using System;
using System.Collections.Generic;
using System.Text;

public class Truck :Vechicle
{
    public Truck(double fuelQuantity,double tankCapacity,double fuelConsumption)
        : base(fuelQuantity,tankCapacity,fuelConsumption) { }

    public override string Drive(double kmToDrive)
    {
        double fuelNeeded = kmToDrive * (FuelConsumption + 1.6);
        bool isAbleToDrive = (FuelQuantity - fuelNeeded) >= 0;
        string result;
        if (isAbleToDrive)
        {
            result = $"Truck travelled {kmToDrive} km";
            FuelQuantity -= fuelNeeded;
        }
        else
        {
            result = "Truck needs refueling";
        }
        return result;
    }
}
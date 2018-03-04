using System;
using System.Collections.Generic;
using System.Text;

public class Car :Vechicle
{
    public Car(double fuelQuantity,double tankCapacity,double fuelConsumption)
    : base(fuelQuantity,tankCapacity, fuelConsumption) { }

    public override string Drive(double kmToDrive)
    {
        double fuelNeeded = kmToDrive * (FuelConsumption + 0.9);
        bool isAbleToDrive = (FuelQuantity - fuelNeeded) >= 0;
        string result;
        if (isAbleToDrive)
        {
            result = $"Car travelled {kmToDrive} km";
            FuelQuantity -= fuelNeeded;
        }
        else
        {
            result = "Car needs refueling";
        }
        return result;
    }
}
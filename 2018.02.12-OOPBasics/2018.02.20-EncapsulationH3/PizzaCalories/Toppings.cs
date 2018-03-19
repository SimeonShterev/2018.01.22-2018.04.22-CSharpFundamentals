using System;
using System.Collections.Generic;

public class Toppings
{
    private double weight;
    private string name;
    private List<string> ingridients = new List<string> { "meat", "veggies", "cheese", "sauce" };

    public Toppings(double weight, string name)
    {
        this.Name = name;
        this.Wieght = weight;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if(!ingridients.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.name = value;
        }
    }

    public double Wieght
    {
        get { return this.weight; }
        set
        {
            if(value<1 || value>50)
            {
                throw new ArgumentException($"{this.name} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public double ToppingType(string toppingType)
    {
        string toppingToLower = toppingType.ToLower();
        switch(toppingToLower)
        {
            case "meat": return 1.2;
            case "veggies": return 0.8;
            case "cheese": return 1.1;
            case "sauce": return 0.9;
            default: throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
        }
    }
}
using System;

public class Dough
{
    private double weight;

    public Dough(double weight)
    {
        this.Weight = weight;
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if(value>200 || value<1)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double FlourType(string flourType)
    {
        switch(flourType)
        {
            case "white": return 1.5;
            case "wholegrain": return 1.0;
            default: throw new ArgumentException("Invalid type of dough.");
        }
    }

    public double BakingTechnique(string bakingTech)
    {
        switch(bakingTech)
        {
            case "crispy": return 0.9;
            case "chewy": return 1.1;
            case "homemade": return 1.0;
            default: throw new ArgumentException("Invalid type of dough.");
        }
    }
}
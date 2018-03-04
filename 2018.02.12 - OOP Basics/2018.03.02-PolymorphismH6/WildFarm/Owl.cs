using System;
using System.Collections.Generic;
using System.Text;

public class Owl :Bird
{
    public Owl(double wingSize, string name, double wieght, int foodEaten) 
        : base(wingSize, name, wieght, foodEaten) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override void WeightIncrease()
    {
        this.Weight
    }
}
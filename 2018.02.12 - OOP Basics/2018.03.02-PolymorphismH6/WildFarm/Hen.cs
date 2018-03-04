using System;
using System.Collections.Generic;
using System.Text;

public class Hen :Bird
{
    public Hen(double wingSize, string name, double wieght, int foodEaten) 
        : base(wingSize, name, wieght, foodEaten) { }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}
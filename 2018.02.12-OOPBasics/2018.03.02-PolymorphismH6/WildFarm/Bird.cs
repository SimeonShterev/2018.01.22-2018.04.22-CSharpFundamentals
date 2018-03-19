using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird :Animal
{
    public Bird(double wingSize, string name, double wieght, int foodEaten)
        :base(name, wieght, foodEaten)
    {
        this.WingSize = wingSize;
    }

    public double WingSize { get; set; }
}
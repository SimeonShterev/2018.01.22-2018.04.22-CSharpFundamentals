using System;
using System.Collections.Generic;
using System.Text;

public abstract class Shape
{
    public abstract double CalculateArea();

    public abstract double CalculatePerimeter();

    public virtual string Draw()
    {
        return "Drawing ";
    }
}
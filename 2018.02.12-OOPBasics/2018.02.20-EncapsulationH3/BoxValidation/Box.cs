using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative. ");
            }
            height = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative. ");
            }
            width = value;
        }
    }

    public double Length
    {
        get { return this.length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative. ");
            }
            this.length = value;
        }
    }

    internal double SurfaceArea()
    {
        return 2 * (length * width + length * height + width * height);
    }

    internal double Volume()
    {
        return length * width * height;
    }

    internal double LateralArea()
    {
        return 2 * (length * height + width * height);
    }

    public override string ToString()
    {
        return $"Surface Area - {this.SurfaceArea():f2}" + Environment.NewLine + $"Lateral Surface Area - {this.LateralArea():f2}" + Environment.NewLine + $"Volume - {this.Volume():f2}";
    }
}

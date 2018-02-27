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

    private double Height
    {
        get { return height; }
        set { height = value; }
    }

    private double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    internal double SurfaceArea(double length, double width, double height)
    {
        return 2 * (length * width + length * height + width * height);
    }

    internal double Volume(double length, double width, double height)
    {
        return length * width * height;
    }

    internal double LateralArea(double length, double width, double height)
    {
        return 2 * (length * height + width * height);
    }
}

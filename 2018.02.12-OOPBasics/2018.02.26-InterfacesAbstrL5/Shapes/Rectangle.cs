using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Height
    {
        get { return this.height; }
        set
        {
            if(value<2)
            {
                throw new ArgumentException("Height zero or negative");
            }
            this.height = value;
        }
    }


    public int Width
    {
        get { return this.width; }
        set
        {
            if (value < 2)
            {
                throw new ArgumentException("Width zero or negative");
            }
            this.width = value;
        }
    }

    public void Draw()
    {
        DrawLine(this.Width, '*', '*');
        for(int i =1;i<this.Height - 1; i++)
        {
            DrawLine(this.Width, ' ', '*');
        }
        DrawLine(this.Width, '*', '*');
    }

    private void DrawLine(int width, char mid, char end)
    {
        Console.Write(end);
        for (int i = 0; i < width-2; i++)
        {
            Console.Write(mid);
        }
        Console.WriteLine(end);
    }
}

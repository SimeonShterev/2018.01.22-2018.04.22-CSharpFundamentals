using System;
using System.Collections.Generic;
using System.Text;

class Rectangle
{
    private string id;
    private int width;
    private int height;
    private int[] topLeft;

    public Rectangle(string id, int width, int height, int[] topLeft)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeft = topLeft;
    }

    public int[] TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }


    public int Height
    {
        get { return height; }
        set { height = value; }
    }


    public int Width
    {
        get { return width; }
        set { width = value; }
    }


    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool CheckIntersection(Rectangle secondRect)
    {
        int x1 = this.topLeft[0];
        int x2 = x1 + this.width;
        int y2 = this.topLeft[1];
        int y1 = y2 - this.height;

        int xTopLeft = secondRect.topLeft[0];
        int yTopLeft = secondRect.topLeft[1];
        int xTopRight = secondRect.topLeft[0] + secondRect.Width;
        int yTopRight = secondRect.topLeft[1];
        int xBottomLeft = secondRect.topLeft[0];
        int yBottomLeft = secondRect.topLeft[0] - secondRect.height;
        int xBottomRight = secondRect.topLeft[0] + secondRect.Width;
        int yBottomRight = secondRect.topLeft[0] - secondRect.height;

        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
	private Point point;

	public Rectangle(int bottomLeftX, int bottomLeftY, int topRightX, int topRightY)
	{
		this.BottomLeftX = bottomLeftX;
		this.BottomLeftY = bottomLeftY;
		this.TopRightX = topRightX;
		this.TopRightY = topRightY;
	}

	public int BottomLeftX { get; set; }

	public int BottomLeftY { get; set; }

	public int TopRightX { get; set; }

	public int TopRightY { get; set; }

	public bool Contains(Point point)
	{
		bool isXInside = point.X >= this.BottomLeftX && point.X <= this.TopRightX;
		bool isYInside = point.Y >= BottomLeftY && point.Y <= this.TopRightY;
		if (isXInside && isYInside)
			return true;
		else
			return false;
	}
}
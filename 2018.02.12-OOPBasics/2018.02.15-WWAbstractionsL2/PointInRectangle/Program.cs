using System;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{

		Rectangle rectangle = CreateRectangle();
		int lines = int.Parse(Console.ReadLine());
		for (int i = 0; i < lines; i++)
		{
			Point point = CreatePoint();
			bool isInside = rectangle.Contains(point);
			Console.WriteLine(isInside);
		}

	}

	private static Point CreatePoint()
	{
		int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int x = pointCoordinates[0];
		int y = pointCoordinates[1];
		Point point = new Point(x, y);
		return point;

	}

	private static Rectangle CreateRectangle()
	{
		int[] rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int bottomLeftX = rectangleCoordinates[0];
		int bottomLeftY = rectangleCoordinates[1];
		int topRightX = rectangleCoordinates[2];
		int topRightY = rectangleCoordinates[3];
		Rectangle rectangle = new Rectangle(bottomLeftX, bottomLeftY, topRightX, topRightY);
		return rectangle;
	}
}
using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		var box = new Box<double>();
		int lines = int.Parse(Console.ReadLine());
		for (int i = 0; i < lines; i++)
		{
			box.Add(double.Parse(Console.ReadLine()));
		}
		double elementToCompare = double.Parse(Console.ReadLine());
		int graterElementsCount = box.GraterElements(elementToCompare);
		Console.WriteLine(graterElementsCount);
	}
}

public class Box<T>
	where T : IComparable
{
	private List<T> list;

	public Box()
	{
		this.list = new List<T>();
	}

	public void Add(T item)
	{
		this.list.Add(item);
	}

	public int GraterElements(T elementToCompare)
	{
		int graterElementsCount = 0;
		foreach (var item in this.list)
		{
			if (item.CompareTo(elementToCompare) == 1)
			{
				graterElementsCount++;
			}
		}
		return graterElementsCount;
	}
}
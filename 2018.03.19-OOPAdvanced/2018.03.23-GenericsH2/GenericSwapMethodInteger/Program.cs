using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		int lines = int.Parse(Console.ReadLine());
		var box = new Box<int>();
		for (int i = 0; i < lines; i++)
		{
			box.Add(int.Parse(Console.ReadLine()));
		}
		int[] indeces = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int firstIndex = indeces[0];
		int secondIndex = indeces[1];
		box.SwapIndeces(firstIndex, secondIndex);
		Console.WriteLine(box);
	}
}

public class Box<T>
{
	private List<T> myList;

	public Box()
	{
		this.myList = new List<T>();
	}

	public void Add(T item)
	{
		this.myList.Add(item);
	}

	public void SwapIndeces(int firstIndex, int secondIndex)
	{
		T firstElement = myList[firstIndex];
		T secondElement = myList[secondIndex];
		this.myList.RemoveAt(firstIndex);
		this.myList.Insert(firstIndex, secondElement);
		this.myList.RemoveAt(secondIndex);
		this.myList.Insert(secondIndex, firstElement);
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var variable in this.myList)
		{
			sb.AppendLine($"{variable.GetType().FullName}: {variable}");
		}
		return sb.ToString().TrimEnd();
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		int lines = int.Parse(Console.ReadLine());
		var box = new Box<string>();
		for (int i = 0; i < lines; i++)
		{
			box.Add(Console.ReadLine());
		}
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
		myList.Add(item);
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
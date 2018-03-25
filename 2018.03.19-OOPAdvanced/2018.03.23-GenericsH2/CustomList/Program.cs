using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		Box<string> box = new Box<string>();
		string input;
		while ((input = Console.ReadLine())!="END")
		{
			string[] commandArgs = input.Split();
			string command = commandArgs[0];
			switch (command)
			{
				case "Add":
					box.Add(commandArgs[1]);
					break;
				case "Remove":
					string itemRemoved = box.Remove(int.Parse(commandArgs[1]));
					//Console.WriteLine(itemRemoved);
					break;
				case "Contains":
					bool boolState = box.Contains(commandArgs[1]);
					Console.WriteLine(boolState);
					break;
				case "Swap":
					box.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
					break;
				case "Greater":
					int greaterThan = box.CountGreaterThan(commandArgs[1]);
					Console.WriteLine(greaterThan);
					break;
				case "Max":
					string maxEl = box.Max();
					Console.WriteLine(maxEl);
					break;
				case "Min":
					string minEl = box.Min();
					Console.WriteLine(minEl);
					break;
				case "Print":
					string output = box.Print();
					Console.WriteLine(output);
					break;
				case "Sort":
					box.Sort();
					break;
			}
		}
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

	public T Remove(int index)
	{
		T removedItem = this.list[index];
		this.list.RemoveAt(index);
		return removedItem;
	}

	public bool Contains(T item)
	{
		bool contain = this.list.Contains(item);
		return contain;
	} 

	public void Swap(int index1, int index2)
	{
		T firstEl = this.list[index1];
		T secondEl = this.list[index2];
		this.list.RemoveAt(index1);
		this.list.Insert(index1, secondEl);
		this.list.RemoveAt(index2);
		this.list.Insert(index2, firstEl);
	}

	public int CountGreaterThan(T elementToCompare)
	{
		int counter = 0;
		foreach (var item in this.list)
		{
			bool isGreaterThan = item.CompareTo(elementToCompare) == 1;
			if(isGreaterThan)
			{
				counter++;
			}
		}
		return counter;
	}

	public T Max()
	{
		return this.list.Max();
	}

	public T Min()
	{
		return this.list.Min();
	}

	public string Print()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var item in this.list)
		{
			sb.AppendLine(item.ToString());
		}
		return sb.ToString().TrimEnd();
	}

	public void Sort()
	{
		this.list.Sort();
	}
}
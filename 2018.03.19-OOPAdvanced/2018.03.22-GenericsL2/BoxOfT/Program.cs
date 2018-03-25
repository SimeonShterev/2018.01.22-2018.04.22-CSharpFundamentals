using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
	}
}

public class Box<T>
{
	private List<T> myList;

	public Box()
	{
		this.myList = new List<T>();
	}

	public void Add(T element)
	{
		this.myList.Add(element);
	}

	public T Remove()
	{
		T element = myList.Last();
		this.myList.RemoveAt(this.myList.Count - 1);
		return element;
	}

	public int Count => this.myList.Count;
}
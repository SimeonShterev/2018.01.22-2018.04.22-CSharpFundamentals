using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
	}
}

public static class ArrayCreator
{
	public static T[] Create<T>(int lenght, T item)
	{
		T[] myArray = new T[lenght];
		for (int i = 0; i < myArray.Length-1; i++)
		{
			myArray[i] = item;
		}
		return myArray;
	}
}
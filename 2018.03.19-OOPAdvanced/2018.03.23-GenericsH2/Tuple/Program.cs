using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		var tuple = new MyTuple<string, string>();
		string[] input = Console.ReadLine().Split();
		tuple.Add(input[0] + " " + input[1], input[2]);
		string[] input2 = Console.ReadLine().Split();
		tuple.Add(input2[0], input2[1]);
		string[] input3 = Console.ReadLine().Split();
		tuple.Add(input3[0], input3[1]);
		Console.WriteLine(tuple);
	}
}

public class MyTuple<T, U>
{
	private Dictionary<T, U> dict;

	public MyTuple()
	{
		this.dict = new Dictionary<T, U>();
	}

	public void Add(T key, U value)
	{
		this.dict.Add(key, value);
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		foreach (var item in this.dict)
		{
			sb.AppendLine($"{item.Key} -> {item.Value}");
		}
		return sb.ToString().TrimEnd();
	}
}

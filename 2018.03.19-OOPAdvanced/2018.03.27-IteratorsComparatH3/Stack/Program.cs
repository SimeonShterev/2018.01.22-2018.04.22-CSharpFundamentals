using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var stack = new Stack<string>();
		string input;
		while ((input = Console.ReadLine()) != "END")
		{
			string[] tokensPlusCommas = input.Split().Skip(1).ToArray();
			string command = input.Split()[0];
			try
			{
				switch (command)
				{
					case "Push":
						string joinedTokens = string.Join("", tokensPlusCommas);
						string[] tokens = joinedTokens.Split(',');
						stack.Push(tokens);
						break;
					case "Pop":
						stack.Pop();
						break;
				}
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		PrintStack(stack);
		PrintStack(stack);
	}

	private static void PrintStack(Stack<string> stack)
	{
		foreach (var token in stack)
		{
			Console.WriteLine(token);
		}
	}
}
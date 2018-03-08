using System;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		int size = int.Parse(Console.ReadLine());
		PrintUpperPart(size);
		PrintBottomPart(size);
	}

	private static void PrintUpperPart(int size)
	{
		for (int i = 1; i <= size; i++)
		{
			string layer = GenerateLayer(i, size);
			Console.Write(layer);
			Console.WriteLine();
		}
	}

	private static void PrintBottomPart(int size)
	{
		for (int i = size - 1; i > 0; i--)
		{
			string layer = GenerateLayer(i, size);
			Console.Write(layer);
			Console.WriteLine();
		}
	}

	private static string GenerateLayer(int i, int size)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(new string(' ', size - i));
		for (int j = 1; j <= i; j++)
		{
			sb.Append("* ");
		}
		sb.Append(new string(' ', size - i));
		return sb.ToString();
	}
}
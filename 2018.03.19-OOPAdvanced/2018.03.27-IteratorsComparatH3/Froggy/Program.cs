using System;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		int[] arrOfStones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
		var stones = new Lake(arrOfStones);
		Console.WriteLine(string.Join(", ", stones));
	}
}
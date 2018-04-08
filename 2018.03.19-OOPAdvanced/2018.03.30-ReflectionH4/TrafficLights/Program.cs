using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Program
{
	static void Main(string[] args)
	{
		List<TrafficLight> lights = Console.ReadLine().Split().Select(x => new TrafficLight(x)).ToList();
		int lines = int.Parse(Console.ReadLine());

		for (int i = 0; i < lines; i++)
		{
			lights.ForEach(l => l.ChangeTrafficLightSignal());
			Console.WriteLine(string.Join(" ", lights));
		}
	}
}

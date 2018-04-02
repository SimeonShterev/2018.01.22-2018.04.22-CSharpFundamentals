using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		int lines = int.Parse(Console.ReadLine());
		var people = new List<Person>();
		for (int i = 0; i < lines; i++)
		{
			string[] data = Console.ReadLine().Split();
			string name = data[0];
			int age = int.Parse(data[1]);
			var person = new Person(name, age);
			people.Add(person);
		}
		var sortedSet = new SortedSet<Person>(people, new SortedSetComparer());
		var hashSet = new HashSet<Person>(people, new HashSetComparer());
		Console.WriteLine(sortedSet.Count);
		Console.WriteLine(hashSet.Count);
	}
}
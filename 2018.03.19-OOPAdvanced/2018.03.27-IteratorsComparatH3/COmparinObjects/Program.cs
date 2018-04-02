using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		List<Person> people = new List<Person>();
		string input;
		while ((input = Console.ReadLine())!="END")
		{
			string[] personData = input.Split();
			string name = personData[0];
			int age = int.Parse(personData[1]);
			string town = personData[2];
			Person person = new Person(name, age, town);
			people.Add(person);
		}
		int index = int.Parse(Console.ReadLine())-1;
		Person personToCompare = people[index];
		int equalPeople = 0;
		foreach (var person in people)
		{
			if(person.Equals(personToCompare))
			{
				equalPeople++;
			}
		}
		if(equalPeople>1)
		{
			Console.WriteLine($"{equalPeople} {people.Count-equalPeople} {people.Count}");
		}
		else
		{
			Console.WriteLine("No matches");
		}
	}
}

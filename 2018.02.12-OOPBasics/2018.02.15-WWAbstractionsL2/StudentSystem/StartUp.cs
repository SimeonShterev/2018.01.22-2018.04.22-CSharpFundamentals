using System;
using System.Collections.Generic;

class StartUp
{
	static void Main()
	{
		Dictionary<string, Student> data = new Dictionary<string, Student>();
		string input;
		while ((input = Console.ReadLine()) != "Exit")
		{
			string[] args = input.Split();
			string command = args[0];
			var name = args[1];
			switch (command)
			{
				case "Create":
					if (!data.ContainsKey(name))
					{
						var age = int.Parse(args[2]);
						var grade = double.Parse(args[3]);
						var student = new Student(name, age, grade);
						data.Add(name, student);
					}
					break;
				case "Show":
					if (data.ContainsKey(name))
					{
						Student student = data[name];
						Console.WriteLine(student);
					}
					break;
			}
		}
	}
}
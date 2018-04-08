using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
	static void Main(string[] args)
	{
		var instance = Activator.CreateInstance(typeof(Axe), WeaponRarity.Common);
		var attributes = instance.GetType().GetCustomAttribute<CustomAttribute>();
		Console.WriteLine($"Author: {attributes.Author}\r\n" +
						  $"Revision: {attributes.Revision}\r\n" +
						  $"Class description: {attributes.Description}\r\n" +
						  $"Reviewers: {string.Join(", ", attributes.Reviewers)}");
		return;
		Engine engine = new Engine();
		engine.Run();
	}
}

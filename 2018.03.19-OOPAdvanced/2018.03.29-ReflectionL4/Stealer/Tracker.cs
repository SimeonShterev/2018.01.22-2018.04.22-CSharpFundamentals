using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public static class Tracker
{
	public static void PrintMethodsByAuthor()
	{
		Type type = typeof(StartUp);
		var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
		foreach (var method in methods)
		{
			foreach (var attribute in method.GetCustomAttributes<SoftUniAttribute>())
			{
				Console.WriteLine(attribute.Name);
			}
		}
	}
}
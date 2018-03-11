using System;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		string monday = "Monday";
		Console.WriteLine((int)MyDaysOfWeek.Monday);
		Console.WriteLine((int)MyDaysOfWeek.Tuesday);
		Console.WriteLine((int)MyDaysOfWeek.Wednesday);
		Enum.TryParse(typeof(MyDaysOfWeek), "Tuesday", out object asd);
		Type qwe = Enum.GetUnderlyingType(typeof(MyDaysOfWeek));
		Console.WriteLine(qwe);
	}
}

enum MyDaysOfWeek
{
	Monday,
	Tuesday = 3,
	Wednesday
}
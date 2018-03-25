using System;

class Program
{
	static void Main(string[] args)
	{
		string[] inputLine1 = Console.ReadLine().Split();
		string firstName = inputLine1[0] + " " + inputLine1[1];
		string lastName = inputLine1[2];
		string city = inputLine1[3];
		var firstTuple = new Threeuple<string, string, string>();
		firstTuple.Create(firstName, lastName, city);
		string[] inputLine2 = Console.ReadLine().Split();
		string name = inputLine2[0];
		int letersOfBeer = int.Parse(inputLine2[1]);
		bool isDrunk = inputLine2[2] == "drunk" ? true : false;
		var secondTuple = new Threeuple<string, int, bool>();
		secondTuple.Create(name, letersOfBeer, isDrunk);
		string[] inputLine3 = Console.ReadLine().Split();
		string name2 = inputLine3[0];
		double accountBalance = double.Parse(inputLine3[1]);
		string bankName = inputLine3[2];
		var thirdTuple = new Threeuple<string, double, string>();
		thirdTuple.Create(name2, accountBalance, bankName);
		Console.WriteLine(firstTuple);
		Console.WriteLine(secondTuple);
		Console.WriteLine(thirdTuple);
	}
}

public class Threeuple<T, U, V>
{
	private Tuple<T, U, V> mytuple;

	public void Create(T item1, U item2, V item3)
	{
		mytuple = new Tuple<T, U, V>(item1, item2, item3);
	}

	public override string ToString()
	{
		return $"{this.mytuple.Item1} -> {this.mytuple.Item2} -> {this.mytuple.Item3}";
	}
}

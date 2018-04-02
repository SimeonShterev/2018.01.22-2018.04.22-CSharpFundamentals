using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		string[] createList = Console.ReadLine().Split();
		List<string> list = createList.Skip(1).ToList();
		var listyIterator = new ListyIterator<string>(list);
		string command;
		while ((command = Console.ReadLine()) != "END")
		{
			try
			{
				switch (command)
				{
					case "Move":
						Console.WriteLine(listyIterator.MoveNext());
						break;
					case "Print":
						Console.WriteLine(listyIterator.Print());
						break;
					case "HasNext":
						Console.WriteLine(listyIterator.HasNext());
						break;
					case "PrintAll":
						Console.WriteLine(string.Join(" ", listyIterator));
						break;
				}
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
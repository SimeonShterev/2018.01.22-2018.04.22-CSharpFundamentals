using System;
using System.Collections.Generic;

namespace Integration
{
    class Program
    {
        static void Main(string[] args)
        {
			var asd = new HashSet<int>();
			asd.Add(1);
			asd.Add(1);
			asd.Remove(3);
			Console.WriteLine(string.Join(", ", asd));
		}
    }
}

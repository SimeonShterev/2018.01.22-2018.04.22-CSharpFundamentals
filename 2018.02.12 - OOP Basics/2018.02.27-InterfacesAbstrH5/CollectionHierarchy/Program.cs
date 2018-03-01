using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = Console.ReadLine().Split().ToList();
        AbstactList programList = new AbstactList(input);
        MyList newList = new MyList(input);
        (MyList)programList.
    }
}
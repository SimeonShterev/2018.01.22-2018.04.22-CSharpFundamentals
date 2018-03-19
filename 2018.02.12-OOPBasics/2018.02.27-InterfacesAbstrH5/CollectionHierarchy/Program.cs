using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = Console.ReadLine().Split().ToList();
        AddCollection addList = new AddCollection();
        AddRemoveCollection addRemoveList = new AddRemoveCollection();
        MyList myList = new MyList();
        addList.Add(input);
        addRemoveList.Add(input);
        myList.Add(input);
        int itemsToRemove = int.Parse(Console.ReadLine());
        addRemoveList.Remove(itemsToRemove);
        myList.Remove(itemsToRemove);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class MyList : IMyList
{
    private List<string> list;

    public MyList()
    {
        list = new List<string>();
    }

    public void Add(List<string> input)
    {
        for (int i = 0; i < input.Count; i++)
        {
            list.Insert(0, input[i]);
            int index = list.IndexOf(input[i]);
            Console.Write($"{index} ");
        }
        Console.WriteLine();
    }

    public int GetNumOfElements()
    {
        return this.list.Count;
    }

    public void Remove(int count)
    {
        for (int i = 0; i < count; i++)
        {
            string elementAtFirstIndex = this.list[0];
            this.list.RemoveAt(0);
            Console.Write($"{elementAtFirstIndex} ");
        }
        Console.WriteLine();
    }
}
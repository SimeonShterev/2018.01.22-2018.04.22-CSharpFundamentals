using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveCollection : IAddRemove
{
    private List<string> list;

    public AddRemoveCollection()
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

    public void Remove(int count)
    {
        for (int i = 0; i < count; i++)
        {
            string elementAtLastIndex = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            Console.Write($"{elementAtLastIndex} ");
        }
        Console.WriteLine();
    }
}
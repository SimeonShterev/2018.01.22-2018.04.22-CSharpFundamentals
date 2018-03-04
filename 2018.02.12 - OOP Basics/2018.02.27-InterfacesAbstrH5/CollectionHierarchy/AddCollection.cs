using System;
using System.Collections.Generic;
using System.Text;

public class AddCollection : IAdd
{
    private List<string> list;

    public AddCollection()
    {
        list = new List<string>();
    }

    public void Add(List<string> input)
    {
        for (int i = 0; i < input.Count; i++)
        {
            list.Add(input[i]);
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : Person, IBuyer
{
    public Rebel(string name, int age, string group) : base(name, age)
    {
        Group = group;
    }
    public string Group { get; set; }

    public int BuyFood()
    {
        return 5;
    }
}
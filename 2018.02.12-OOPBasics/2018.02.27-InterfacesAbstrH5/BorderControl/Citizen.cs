using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : Person, IBuyer
{
    public Citizen(string name, int age) : base(name, age)
    {
    }

    public int BuyFood()
    {
        return 10;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class Dog :Animal
{
    public Dog(string name,string favouriteFood)
        : base(name,favouriteFood) { }

    public override string MakeSound()
    {
        return base.MakeSound() + Environment.NewLine + "DJAAF";
    }
}
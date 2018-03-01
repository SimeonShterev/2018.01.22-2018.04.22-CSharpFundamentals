using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IResident, IPerson
{
    public Citizen(string name, string country, int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }

    public string Name { get; set; }
    public string Country { get; set; }
    public int Age { get; set; }


    string IPerson.GetName()
    {
        return Name;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {Name}";
    }
}
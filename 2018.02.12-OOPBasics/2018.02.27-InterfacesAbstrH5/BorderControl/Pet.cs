using System;
using System.Collections.Generic;
using System.Text;

public class Pet
{
    public Pet(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }
    public DateTime BirthDate { get; set; }
    public string Name { get; set; }
}
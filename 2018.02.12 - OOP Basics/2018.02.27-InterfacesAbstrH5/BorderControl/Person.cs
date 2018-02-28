using System;
using System.Collections.Generic;
using System.Text;

public class Person : Robot, IAge
{
    public Person(string id, string name, int age, DateTime birthDate) : base(id, name)
    {
        Age = age;
        BirthDate = birthDate;
    }

    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
}
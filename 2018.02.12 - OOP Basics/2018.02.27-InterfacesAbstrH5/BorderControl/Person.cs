using System;
using System.Collections.Generic;
using System.Text;

public class Person : Robot
{
    private List<string> list = new List<string>();
    public Person(string id, string name, int age):base(id, name)
    {
        Age = age;
    }

    public int Age { get; set; }
}
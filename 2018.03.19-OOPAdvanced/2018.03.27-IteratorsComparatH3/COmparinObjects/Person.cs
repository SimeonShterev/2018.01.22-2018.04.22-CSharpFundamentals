using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
	private string name;
	private int age;
	private string town;

	public Person(string name, int age, string town)
	{
		this.name = name;
		this.age = age;
		this.town = town;
	}

	public int CompareTo(Person other)
	{
		int name = this.name.CompareTo(other.name);
		int age = this.age.CompareTo(other.age);
		int town = this.town.CompareTo(other.town);
		if (name == 0 && age == 0 && town == 0)
		{
			return 0;
		}
		else
		{
			return 1;
		}
	}

	public override bool Equals(object other)
	{
		int result = CompareTo((Person)other);
		if (result == 0)
		{
			return true; 
		}
		return false;
	}
}
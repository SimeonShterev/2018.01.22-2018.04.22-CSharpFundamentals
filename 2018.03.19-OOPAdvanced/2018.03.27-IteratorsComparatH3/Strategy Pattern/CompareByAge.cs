using System;
using System.Collections.Generic;
using System.Text;

public class CompareByAge : IComparer<Person>
{
	public int Compare(Person x, Person y)
	{
		int age = x.age.CompareTo(y.age);
		return age;
	}
}
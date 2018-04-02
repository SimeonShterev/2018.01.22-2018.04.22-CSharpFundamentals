using System;
using System.Collections.Generic;
using System.Text;

public class SortedSetComparer : IComparer<Person>
{
	public int Compare(Person x, Person y)
	{
		int name = x.name.CompareTo(y.name);
		if(name==0)
		{
			int age = x.age.CompareTo(y.age);
			return age;
		}
		return name;
	}
}
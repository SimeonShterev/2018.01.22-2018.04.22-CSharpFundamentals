using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class HashSetComparer : IEqualityComparer<Person>
{
	public bool Equals(Person x, Person y)
	{
		int name = x.name.CompareTo(y.name);
		int age = x.age.CompareTo(y.age);
		if (name == 0 && age==0)
		{
			return true;
		}
		return false;
	}

	public int GetHashCode(Person obj)
	{
		return base.GetHashCode();
	}
}
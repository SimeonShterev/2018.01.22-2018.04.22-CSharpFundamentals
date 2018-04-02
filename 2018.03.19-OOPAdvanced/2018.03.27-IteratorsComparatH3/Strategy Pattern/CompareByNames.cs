using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CompareByNames : IComparer<Person>
{

	public int Compare(Person x, Person y)
	{
		int nameLenght = x.name.Length.CompareTo(y.name.Length);
		if(nameLenght==0)
		{
			int firstLetter = char.ToLower(x.name[0]).CompareTo(char.ToLower(y.name[0]));
			return firstLetter;
		}
		return nameLenght;
	}
}
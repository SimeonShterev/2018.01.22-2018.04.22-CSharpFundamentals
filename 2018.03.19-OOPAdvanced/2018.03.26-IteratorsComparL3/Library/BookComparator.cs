using System;
using System.Collections.Generic;
using System.Text;

public class BookComparator : IComparer<Book>
{
	public int Compare(Book that, Book other)
	{
		int result = that.Title.CompareTo(other.Title);
		if (result == 0)
		{
			return other.Year.CompareTo(that.Year);
		}
		return result;
	}
}
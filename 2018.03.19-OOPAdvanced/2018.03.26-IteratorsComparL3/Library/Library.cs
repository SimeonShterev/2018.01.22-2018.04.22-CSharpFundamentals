using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>	
{
	private Book[] books;
	private IComparer<Book> comparer;

	public Library(params Book[] books)
	{
		Array.Sort(books, new BookComparator());
		this.books = books;
	}

	public IEnumerator<Book> GetEnumerator()
	{
		return new LibraryIterator(this.books);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}
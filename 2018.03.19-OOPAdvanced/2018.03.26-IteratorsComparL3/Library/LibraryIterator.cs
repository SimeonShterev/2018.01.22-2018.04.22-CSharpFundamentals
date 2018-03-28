using System.Collections;
using System.Collections.Generic;

public class LibraryIterator : IEnumerator<Book>
{
	private Book[] books;
	private int currentIndex;

	public LibraryIterator(Book[] books)
	{
		this.Reset();
		this.books = books;
	}

	public Book Current => this.books[this.currentIndex];

	object IEnumerator.Current => this.Current;

	public void Dispose() { }

	public bool MoveNext()
	{
		bool isValid = this.currentIndex + 1 < this.books.Length;
		if (isValid)
		{
			this.currentIndex++;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void Reset()
	{
		this.currentIndex = -1;
	}
}
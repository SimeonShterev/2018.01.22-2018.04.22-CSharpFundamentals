using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerator<T>, IEnumerable<T>
{
	private List<T> list;

	private int currentIndex;

	public ListyIterator(List<T> list)
	{
		Reset();
		this.list = list;
	}

	public T Current => this.list[currentIndex];

	object IEnumerator.Current => currentIndex;

	public void Dispose() { }

	public T Print()
	{
		if(!this.list.Any())
		{
			throw new InvalidOperationException("Invalid Operation!");
		}
		return this.list[currentIndex];
	}

	public bool HasNext()
	{
		bool isValid = this.currentIndex + 1 < this.list.Count;
		if (isValid)
		{
			return true;
		}
		else
		{
			return false;
		}

	}

	public bool MoveNext()
	{
		bool isValid = this.currentIndex + 1 < this.list.Count;
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
		this.currentIndex = 0;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < this.list.Count; i++)
		{
			yield return this.list[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
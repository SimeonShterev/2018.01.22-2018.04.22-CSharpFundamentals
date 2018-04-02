using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
	private List<T> stack;

	public Stack()
	{
		this.stack = new List<T>();
	}

	public void Push(params T[] tokens)
	{
		foreach (var token in tokens)
		{
			this.stack.Add(token);
		}
	}

	public void Pop()
	{
		if(!this.stack.Any())
		{
			throw new InvalidOperationException("No elements");
		}
		this.stack.RemoveAt(this.stack.Count - 1);
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = this.stack.Count - 1; i >= 0; i--)
		{
			yield return this.stack[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
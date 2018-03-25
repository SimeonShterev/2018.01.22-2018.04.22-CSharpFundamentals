using System;

class Program
{
	static void Main(string[] args)
	{
	}
}

public class Scale<T>
	where T : IComparable<T>
{
	private T left;
	private T right;

	public Scale(T left, T right)
	{
		this.left = left;
		this.right = right;
	}

	public T GetHeavier()
	{
		int heavier = this.left.CompareTo(this.right);
		if(heavier>0)
		{
			return this.left;
		}
		if(heavier<0)
		{
			return this.right;
		}
		return default(T);
	}
}
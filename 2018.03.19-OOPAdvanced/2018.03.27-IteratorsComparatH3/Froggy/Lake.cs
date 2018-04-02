using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
	private int[] stones;

	public Lake(int[] stones)
	{
		this.stones = stones;
	}

	public IEnumerator<int> GetEnumerator()
	{
		int maxEvenIndex = this.stones.Length % 2 == 0 ? this.stones.Length - 1 : this.stones.Length - 2;
		for (int i = 0; i < this.stones.Length; i += 2)
		{
			yield return this.stones[i];
		}
		for (int i = maxEvenIndex; i >= 0; i -= 2)
		{
			yield return this.stones[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
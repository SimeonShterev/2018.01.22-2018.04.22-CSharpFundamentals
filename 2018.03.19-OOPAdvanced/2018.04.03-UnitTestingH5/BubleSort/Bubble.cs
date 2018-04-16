using System;
using System.Collections.Generic;
using System.Text;

namespace BubleSort
{
    public class Bubble
    {
		private int[] array;

		public Bubble(params int[] input)
		{
			this.array = input;
		}

		public void Sort()
		{
			int length = this.array.Length;
			for (int i = 0; i < length; i++)
			{
				for (int k = 0; k < length - 1; k++)
				{
					if (this.array[k] > this.array[k + 1])
					{
						int temp = this.array[k];
						this.array[k] = this.array[k + 1];
						this.array[k + 1] = temp;
					}
				}
			}
		}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorTest
{
    public class ListIterator
    {
		private string[] array;
		private int currentIndex;
		private int lenght;
		private string printMethodOutput;

		public ListIterator(params string[] input)
		{
			if(input == null)
			{
				throw new ArgumentNullException("Empty input");
			}
			this.array =  input;
			this.currentIndex = 0;
			this.lenght = input.Length;
			this.printMethodOutput = null;
		}

		public bool Move()
		{
			if(this.currentIndex+1 >= this.lenght)
			{
				return false;
			}
			this.currentIndex++;
			return true;
		}

		public void Print()
		{
			if(this.lenght == 0)
			{
				throw new InvalidOperationException("Invalid Operation!");
			}
			this.printMethodOutput = this.array[currentIndex];
			Console.WriteLine(this.printMethodOutput);
		}

		public bool HasNext()
		{
			if (this.currentIndex + 1 >= this.lenght)
			{
				return false;
			}
			return true;
		}
    }
}

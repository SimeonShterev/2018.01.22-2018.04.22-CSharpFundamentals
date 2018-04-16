using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class DataBase<T>
    {
		private const int defaultCapasity = 16;

		private T[] array;
		private int currentIndex;

		public DataBase(params T[] inputValues)
		{
			this.array = new T[defaultCapasity];
			this.currentIndex = 0;
			Array.Copy(inputValues, this.array, inputValues.Length);
			this.currentIndex = inputValues.Length;
		}

		public int CurrentIndex => this.currentIndex;

		public T LastValue => this.array[this.currentIndex-1];

		public void Add(T value)
		{
			if(this.currentIndex>=defaultCapasity)
			{
				throw new InvalidOperationException("Array is full!");
			}
			this.array[this.currentIndex] = value;
			this.currentIndex++;
		}

		public void Remove()
		{
			if(this.currentIndex==0)
			{
				throw new InvalidOperationException("Array is empty!");
			}
			this.currentIndex--;
			this.array[this.currentIndex] = default(T);
		}

		public T[] Fetch()
		{
			T[] arrayToReturn = new T[this.currentIndex];
			Array.Copy(this.array, arrayToReturn, this.currentIndex);
			return arrayToReturn;
		}
    }
}

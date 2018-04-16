using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
	public class ExtendedDatabase
	{
		private const int defaultCapasity = 16;

		private Person[] arrayOfPeople;
		private int currentIndex;

		public ExtendedDatabase(params Person[] inputValues)
		{
			this.arrayOfPeople = new Person[defaultCapasity];
			this.currentIndex = 0;
			Array.Copy(inputValues, this.arrayOfPeople, inputValues.Length);
			this.currentIndex = inputValues.Length;
		}

		public int CurrentIndex => this.currentIndex;

		public void Add(Person person)
		{
			if (this.currentIndex >= defaultCapasity)
			{
				throw new InvalidOperationException("Array is full!");
			}
			for (int i = 0; i < this.currentIndex; i++)
			{
				if(arrayOfPeople[i].UserName == person.UserName)
				{
					throw new InvalidOperationException("Person with the same name already exists!");
				}
				if (arrayOfPeople[i].Id == person.Id)
				{
					throw new InvalidOperationException("Person with same id already exists!");
				}
			}

			this.arrayOfPeople[this.currentIndex] = person;
			this.currentIndex++;
		}

		public void Remove()
		{
			if (this.currentIndex == 0)
			{
				throw new InvalidOperationException("Array is empty!");
			}
			this.currentIndex--;
			this.arrayOfPeople[this.currentIndex] = null;
		}

		public Person FindById(long id)
		{
			Person personToFind = null;
			for (int i = 0; i < this.currentIndex; i++)
			{
				if(arrayOfPeople[i].Id == id)
				{
					personToFind = arrayOfPeople[i];
					break;
				}
			}
			if(personToFind==null)
			{
				throw new InvalidOperationException("Person with provided ID not found!");
			}
			if (personToFind.Id < 0)
			{
				throw new ArgumentException("Negative ID");
			}
			return personToFind;
		}

		public Person FindByUsername(string userName)
		{
			Person personToFind = null;
			for (int i = 0; i < this.currentIndex; i++)
			{
				if (arrayOfPeople[i].UserName == userName)
				{
					personToFind = arrayOfPeople[i];
					break;
				}
			}
			if (personToFind == null)
			{
				throw new InvalidOperationException("Person with provided username not found!");
			}
			if (personToFind.UserName == null)
			{
				throw new ArgumentNullException("No username set!");
			}
			return personToFind;
		}

		public Person[] Fetch()
		{
			Person[] arrayToReturn = new Person[this.currentIndex];
			Array.Copy(this.arrayOfPeople, arrayToReturn, this.currentIndex);
			return arrayToReturn;
		}
	}
}

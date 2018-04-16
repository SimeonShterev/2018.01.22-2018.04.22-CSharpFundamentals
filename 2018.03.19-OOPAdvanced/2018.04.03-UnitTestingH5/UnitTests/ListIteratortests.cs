using IteratorTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    public class ListIteratortests
    {
		[Test]
		public void TestConstructor()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator(input);

			FieldInfo arrayInfo = GetArrayField();
			FieldInfo currentIndexInfo = GetCurrentIndexField();
			string[] actualArray = (string[])arrayInfo.GetValue(listIterator);
			int currentIndex = (int)currentIndexInfo.GetValue(listIterator);

			Assert.That(input, Is.EqualTo(actualArray));
			Assert.That(currentIndex, Is.EqualTo(0));
		}

		[Test]
		public void TestPassingEmtyArrayToCtorThrowsArgumentNullEx()
		{
			Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
		}

		[Test]
		public void MoveMethodReturnsTrue()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator();

			int currentIndex = 0;
			InitiliseListIterator(input, listIterator ,currentIndex);

			bool result = listIterator.Move();

			Assert.That(result == true);
		}

		[Test]
		public void MoveMethodReturnsFalse()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator();

			int currentIndex = 1;
			InitiliseListIterator(input, listIterator, currentIndex);

			bool result = listIterator.Move();

			Assert.That(result == false);
		}

		[Test]
		public void PrintMethodInvalid()
		{
			ListIterator listIterator = new ListIterator();

			Assert.That(() => listIterator.Print(), Throws.InvalidOperationException);
		}

		[Test]
		public void PrintMethodValid()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator();

			int currentIndex = 0;
			InitiliseListIterator(input, listIterator, currentIndex);

			listIterator.Print();
			string expectedOutput = (string)typeof(ListIterator).GetField("printMethodOutput", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(listIterator);

			Assert.That(input[currentIndex], Is.EqualTo(expectedOutput));
		}

		[Test]
		public void HasNextMethodReturnsTrue()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator();

			int currentIndex = 0;
			InitiliseListIterator(input, listIterator, currentIndex);

			bool result = listIterator.HasNext();

			Assert.That(result == true);
		}

		[Test]
		public void HasNextMethodReturnsFalse()
		{
			string[] input = new string[] { "Pesho", "word" };
			ListIterator listIterator = new ListIterator();

			int currentIndex = 1;
			InitiliseListIterator(input, listIterator, currentIndex);

			bool result = listIterator.HasNext();

			Assert.That(result == false);
		}

		private static void InitiliseListIterator(string[] input, ListIterator listIterator, int currentIndex)
		{
			FieldInfo arrayInfo = GetArrayField();
			arrayInfo.SetValue(listIterator, input);
			FieldInfo currentIndexInfo = GetCurrentIndexField();
			currentIndexInfo.SetValue(listIterator, currentIndex);
			FieldInfo lengtInfo = GetLenght();
			lengtInfo.SetValue(listIterator, input.Length);
		}

		private static FieldInfo GetLenght()
		{
			return typeof(ListIterator).GetField("lenght", BindingFlags.NonPublic | BindingFlags.Instance);
		}

		private static FieldInfo GetCurrentIndexField()
		{
			return typeof(ListIterator).GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);
		}

		private static FieldInfo GetArrayField()
		{
			return typeof(ListIterator).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(string[]));
		}
	}
}

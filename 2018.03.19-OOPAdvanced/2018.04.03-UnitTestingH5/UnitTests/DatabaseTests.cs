using Database;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
	public class DatabaseTests
	{
		private const int defaultCapasity = 16;

		static int[][] Parameters = new int[][]
		{
			new int[] { 1,2,3,4 },
			new int[] { int.MinValue, int.MaxValue },
			new int[] {  }
		};

		[Test]
		[TestCaseSource(nameof(Parameters))]
		//[TestCase(new int[] { 1, 2, 3, 4 })]
		//[TestCase(new int[] { int.MinValue, int.MaxValue })]
		//[TestCase(new int[] { 0 })]
		//[TestCase(new int[] { })]
		public void DoesConstructorInitialiseValues(int[] values)
		{
			DataBase<int> db = new DataBase<int>(values);

			int lenght = values.Length;
			FieldInfo arrayInfo = GetArray(db);
			int[] fieldValue = (int[])arrayInfo.GetValue(db);
			values = values.Concat(new int[defaultCapasity - lenght]).ToArray();

			Assert.That(db.CurrentIndex == lenght);
			Assert.That(values, Is.EquivalentTo(fieldValue));
		}

		[Test]
		[TestCase(0)]
		[TestCase(int.MinValue)]
		[TestCase(int.MaxValue)]
		[TestCase(-21)]
		public void AddMethodAddsNumberToDatabase(int value)
		{
			DataBase<int> db = new DataBase<int>();
			FieldInfo currentIndex = GetCurentIndex(db);
			currentIndex.SetValue(db, 0);

			db.Add(value);

			Assert.That(db.CurrentIndex == 1 && db.LastValue == value);
		}

		[Test]
		public void DoesAddMethodThrowsException()
		{
			DataBase<int> db = new DataBase<int>();

			FieldInfo currentIndex = GetCurentIndex(db);
			currentIndex.SetValue(db, defaultCapasity);

			Assert.That(() => db.Add(9), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { int.MinValue, int.MaxValue })]
		[TestCase(new int[] { 0 })]
		public void DoesRemoveMethodRemovesNumberFromDatabase(int[] values)
		{
			DataBase<int> db = new DataBase<int>();

			int lenght = values.Length;
			FieldInfo currentIndex = GetCurentIndex(db);
			currentIndex.SetValue(db, lenght);
			FieldInfo arrayInfo = GetArray(db);
			arrayInfo.SetValue(db, values.Concat(new int[defaultCapasity - lenght]).ToArray());

			db.Remove();
			int[] fieldValue = (int[])arrayInfo.GetValue(db);
			int[] array = values.Take(lenght - 1).ToArray();
			array = array.Concat(new int[defaultCapasity + 1 - lenght]).ToArray();

			Assert.That(array, Is.EquivalentTo(fieldValue));
		}

		[Test]
		public void DoesRemoveMethodThrowsException()
		{
			DataBase<int> db = new DataBase<int>();

			int index = 0;
			FieldInfo currentIndex = GetCurentIndex(db);
			currentIndex.SetValue(db, index);

			Assert.That(() => db.Remove(), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { int.MinValue, int.MaxValue })]
		[TestCase(new int[] { 0 })]
		[TestCase(new int[] { })]
		public void DoesFetchMethodReturnsSameObject(int[] values)
		{
			DataBase<int> db = new DataBase<int>();

			FieldInfo array = GetArray(db);
			array.SetValue(db, values);
			FieldInfo currentIndexInfo = GetCurentIndex(db);
			currentIndexInfo.SetValue(db, values.Length);

			int[] actualArray = db.Fetch();

			Assert.That(actualArray, Is.EquivalentTo(values));
		}

		private static FieldInfo GetCurentIndex(DataBase<int> db)
		{
			return db.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int));
		}

		private static FieldInfo GetArray(DataBase<int> db)
		{
			return db.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));
		}
	}
}

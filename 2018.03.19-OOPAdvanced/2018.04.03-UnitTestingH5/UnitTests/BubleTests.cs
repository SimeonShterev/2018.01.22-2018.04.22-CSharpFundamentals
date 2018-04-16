using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BubleSort
{
	public class BubleTests
	{
		[Test]
		[TestCase(new int[] { 1, 4, 6, 3, 2 })]
		[TestCase(new int[] { 1, 4, 0, 1, 2, 1 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { })]
		public void TestConstructorValid(int[] values)
		{
			Bubble bubble = new Bubble(values);

			FieldInfo arrayInfo = GetArrayField();
			int[] actualArray = (int[])arrayInfo.GetValue(bubble);

			Assert.That(values, Is.EqualTo(actualArray));
		}

		[Test]
		[TestCase(new int[] { 1, 4, 6, 3, 2 })]
		[TestCase(new int[] { 1, 4, 0, 1, 2, 1 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { })]
		public void TestSortMethodValid(int[] values)
		{
			Bubble bubble = new Bubble();
			int[] copyOfValues = (int[])values.Clone();
			FieldInfo arrayInfo = GetArrayField();
			arrayInfo.SetValue(bubble, copyOfValues);

			bubble.Sort();
			int[] actualArray = (int[])arrayInfo.GetValue(bubble);
			Array.Sort(values);

			Assert.That(values, Is.EqualTo(actualArray));
		}

		private FieldInfo GetArrayField()
		{
			return typeof(Bubble).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int[]));
		}
	}
}

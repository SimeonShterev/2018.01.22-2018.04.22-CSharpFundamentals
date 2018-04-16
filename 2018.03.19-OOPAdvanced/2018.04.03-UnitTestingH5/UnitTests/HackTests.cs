using Hack;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
	public class HackTests
	{
		[Test]
		[TestCase(0)]
		[TestCase(-10)]
		[TestCase(10)]
		[TestCase(int.MinValue)]
		public void TestMathAbs(double value)
		{
			MathDublicate mathDublicate = new MathDublicate();

			double result = mathDublicate.MathAbs(value);
			if (value < 0)
				value = -value;

			Assert.That(result, Is.EqualTo(value));
		}

		[Test]
		[TestCase(0)]
		[TestCase(-10.5)]
		[TestCase(-10.0)]
		[TestCase(10.3)]
		public void TestMathFloor(double value)
		{
			MathDublicate mathDublicate = new MathDublicate();

			double result = mathDublicate.MathFloor(value);
			double ost = value % 1;
			if (value < 0)
			{
				if (ost != 0)
				{
					value = (int)value - 1;
				}
			}
			else
			{
				value = (int)value;
			}

			Assert.That(result, Is.EqualTo(value));
		}
	}
}

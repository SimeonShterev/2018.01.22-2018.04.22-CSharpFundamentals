using Database;
using DateTimeAddDays;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    public class DateTimeTests
    {
		[Test]
		public void TestDateTimeValid()
		{
			Mock<IDateTimeNow> dateMock = new Mock<IDateTimeNow>();
			DateTime fakeDate = new DateTime(2015, 03, 31);
		}
    }
}

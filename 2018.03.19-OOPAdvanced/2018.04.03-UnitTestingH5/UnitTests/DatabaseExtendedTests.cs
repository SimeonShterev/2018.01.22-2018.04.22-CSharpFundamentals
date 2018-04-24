using Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
	public class DatabaseExtendedTests
	{
		private const int defaultCapacity = 16;

		static Person[][] Parameters = new Person[][]
		{
			new Person[] {new Person( 1, "Pesho" ), new Person(2, "Gosho") },
			new Person[] {new Person( 1, "Simo" ), new Person(10, "PedroEskobar") },
		};

		[Test]
		[TestCaseSource(nameof(Parameters))]
		public void TestConstructor(Person[] people)
		{
			ExtendedDatabase db = new ExtendedDatabase(people);

			FieldInfo peopleInfo = GetPeopleArrayField();
			Person[] actualPeople = (Person[])peopleInfo.GetValue(db);
			Person[] buffer = new Person[defaultCapacity - people.Length];

			Assert.That(people.Concat(buffer), Is.EquivalentTo(actualPeople));
		}

		[Test]
		public void TestAddMethodValid()
		{
			Person[] people = new Person[] { new Person(1, "Gosho"), new Person(2, "Pesho") };
			ExtendedDatabase db = new ExtendedDatabase();

			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, 0);
			FieldInfo peopleInfo = GetPeopleArrayField();

			db.Add(people[0]);
			db.Add(people[1]);

			Person[] actualPeople = (Person[])peopleInfo.GetValue(db);
			people = people.Concat(new Person[defaultCapacity - people.Length]).ToArray();
			Assert.That(people, Is.EqualTo(actualPeople));
		}

		[Test]
		public void TestAddMethorThrowExceptionWhenItsFull()
		{
			Person person = new Person(1, "Ivan");
			ExtendedDatabase db = new ExtendedDatabase();

			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, defaultCapacity);

			Assert.That(() => db.Add(person), Throws.InvalidOperationException);
		}

		[Test]
		public void AddMethodThrowExceptionWhenDublicateData()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			Person personWithSameName = new Person(3, "Pesho");
			Assert.That(() => db.Add(personWithSameName), Throws.InvalidOperationException);

			Person personWithSameId = new Person(2, "Ivan");
			Assert.That(() => db.Add(personWithSameId), Throws.InvalidOperationException);
		}

		[Test]
		public void TestRemoveMethodValid()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			db.Remove();
			Person[] actualPeople = (Person[])peopleInfo.GetValue(db);
			people = people.Take(people.Length - 1).Concat(new Person[defaultCapacity + 1 - people.Length]).ToArray();

			Assert.That(people, Is.EquivalentTo(actualPeople));
		}

		[Test]
		public void TestRemoveMethodInvalid()
		{
			ExtendedDatabase db = new ExtendedDatabase();

			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, 0);

			Assert.That(() => db.Remove(), Throws.InvalidOperationException);
		}

		[Test]
		public void TestFindByIDMethodValid()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			int id = 2;
			Person personFound = db.FindById(id);

			Assert.AreEqual(personFound, people[1]);
		}

		[Test]
		public void TestFindByIDCannotFindfPerson()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			Assert.That(() => db.FindById(100), Throws.InvalidOperationException);
		}

		[Test]
		public void TestFindByIDNegativeID()
		{
			Person[] people = new Person[] { new Person(-10, "Pesho"), new Person(2, "Gosho") };
			ExtendedDatabase db = new ExtendedDatabase();
			Person[] buffer = new Person[defaultCapacity - people.Length];
			FieldInfo peopleInfo = GetPeopleArrayField();
			peopleInfo.SetValue(db, people.Concat(buffer).ToArray());
			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, people.Length);

			Assert.That(() => db.FindById(-10), Throws.ArgumentException);
		}

		[Test]
		public void TestFindByUsernameValid()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			Person personFound = db.FindByUsername("Pesho");

			Assert.AreEqual(personFound, people[0]);
		}

		[Test]
		public void TestFindByUsernameCannotFindfPerson()
		{
			Person[] people;
			ExtendedDatabase db;
			FieldInfo peopleInfo;
			InitialiseDataBase(out people, out db, out peopleInfo);

			Assert.That(() => db.FindByUsername("Ivan"), Throws.InvalidOperationException);
		}

		[Test]
		public void TestFindByUsernameThrowsUsernameIsNull()
		{
			Person[] people = new Person[] { new Person(1, null), new Person(2, "Gosho") };
			ExtendedDatabase db = new ExtendedDatabase();
			Person[] buffer = new Person[defaultCapacity - people.Length];
			FieldInfo peopleInfo = GetPeopleArrayField();
			peopleInfo.SetValue(db, people.Concat(buffer).ToArray());
			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, people.Length);

			Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
		}


		private static void InitialiseDataBase(out Person[] people, out ExtendedDatabase db, out FieldInfo peopleInfo)
		{
			people = new Person[] { new Person(1, "Pesho"), new Person(2, "Gosho") };
			db = new ExtendedDatabase();
			Person[] buffer = new Person[defaultCapacity - people.Length];
			peopleInfo = GetPeopleArrayField();
			peopleInfo.SetValue(db, people.Concat(buffer).ToArray());
			FieldInfo currentIndexinfo = GetCurrentIndexField();
			currentIndexinfo.SetValue(db, people.Length);
		}

		private static FieldInfo GetCurrentIndexField()
		{
			return typeof(ExtendedDatabase).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(int));
		}

		private static FieldInfo GetPeopleArrayField()
		{
			return typeof(ExtendedDatabase).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));
		}
	}
}

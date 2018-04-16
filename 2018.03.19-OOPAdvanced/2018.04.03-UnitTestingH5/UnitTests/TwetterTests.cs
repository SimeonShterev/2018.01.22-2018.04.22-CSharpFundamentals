using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Twetterr.Contracts;
using Twetterr.Models;

namespace UnitTests
{
	public class TwetterTests
	{
		[Test]
		[TestCase(null)]
		[TestCase("  ")]
		public void TestTwetterConstructorInvalid(string message)
		{
			Assert.That(() => new Twetter(message), Throws.ArgumentNullException);
		}

		[Test]
		[TestCase("bla bla")]
		[TestCase("abra kadabra")]
		public void TestTwetterClassRetrieveProperMessage(string message)
		{
			IMessage tweet = new Twetter(message);

			string expectedMessage = tweet.RetrieveMessage();

			Assert.That(message, Is.EqualTo(expectedMessage), "Messages differ");
		}

		[Test]
		[TestCase("something")]
		[TestCase("abra kadabra")]
		public void TestWriteMessageOnConsoleMethodValid(string message)
		{
			IServer server = (IServer)Activator.CreateInstance(typeof(Server));
			IClient oven = (IClient)Activator.CreateInstance(typeof(MicrowaveOven), server);

			oven.WriteOnConsole(message);
			FieldInfo messgeInfo = typeof(MicrowaveOven).GetField("messageWrittenOnConsole", BindingFlags.NonPublic | BindingFlags.Instance);

			string expectedMessage = (string)messgeInfo.GetValue(oven);

			Assert.That(message, Is.EqualTo(expectedMessage), "Messages differ");
		}

		[Test]
		[TestCase()]
		public void TestCountOfAllClientMethodsInvokations()
		{
			string[] messages = new string[] { "something", "abracadabra", "trololol" };
			IServer server = (IServer)Activator.CreateInstance(typeof(Server));
			IClient oven = (IClient)Activator.CreateInstance(typeof(MicrowaveOven), server);

			int length = messages.Length;
			foreach (var message in messages)
			{
				oven.SendToServer(message);
			}

			FieldInfo numberOfInvokationsInfo = typeof(MicrowaveOven).GetField("numberOfInvokations", BindingFlags.Instance | BindingFlags.NonPublic);

			int numberOfInvokations = (int)numberOfInvokationsInfo.GetValue(oven);

			Assert.That(numberOfInvokations, Is.EqualTo(length));
		}

		[Test]
		public void TestServerCounter()
		{
			string[] messages = new string[] { "something", "abracadabra", "trololol" };
			IServer server = (IServer)Activator.CreateInstance(typeof(Server));
			FieldInfo counterInfo = typeof(Server).GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
			counterInfo.SetValue(server, 0);

			int length = messages.Length;
			foreach (var message in messages)
			{
				server.SaveToServer(message);
			}
			Dictionary<int, string> data = new Dictionary<int, string>();
			for (int i = 1; i <= length; i++)
			{
				data.Add(i, messages[i - 1]);
			}

			object counter = counterInfo.GetValue(server);

			Assert.That(length, Is.EqualTo(counter));
		}

		[Test]
		public void TestServerStoreMessages()
		{
			string[] messages = new string[] { "something", "abracadabra", "trololol" };
			IServer server = (IServer)Activator.CreateInstance(typeof(Server));

			int length = messages.Length;
			foreach (var message in messages)
			{
				server.SaveToServer(message);
			}
			Dictionary<int, string> data = new Dictionary<int, string>();
			for (int i = 1; i <= length; i++)
			{
				data.Add(i, messages[i - 1]);
			}

			FieldInfo dataInfo = typeof(Server).GetField("messages", BindingFlags.Instance | BindingFlags.NonPublic);
			object actualData = dataInfo.GetValue(server);

			Assert.That(data, Is.EqualTo(actualData));
		}
	}
}

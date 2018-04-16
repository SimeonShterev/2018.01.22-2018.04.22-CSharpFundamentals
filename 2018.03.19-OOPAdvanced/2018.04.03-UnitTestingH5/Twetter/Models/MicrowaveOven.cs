using System;
using System.Collections.Generic;
using System.Text;
using Twetterr.Contracts;

namespace Twetterr.Models
{
	public class MicrowaveOven : IClient
	{
		private IServer server;
		private string messageWrittenOnConsole;
		private int numberOfInvokations;

		public MicrowaveOven(IServer server)
		{
			this.server = server;
			this.numberOfInvokations = 0;
		}

		public void RecieveMessage(IMessage tweet)
		{
			string message = tweet.RetrieveMessage();
			this.WriteOnConsole(message);
			this.SendToServer(message);
		}

		public void SendToServer(string message)
		{
			this.server.SaveToServer(message);
			this.numberOfInvokations++;
		}

		public void WriteOnConsole(string message)
		{
			this.messageWrittenOnConsole = message;
			Console.WriteLine(message);
		}
	}
}

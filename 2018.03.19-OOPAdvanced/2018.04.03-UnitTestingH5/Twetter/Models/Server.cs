using System;
using System.Collections.Generic;
using System.Text;
using Twetterr.Contracts;

namespace Twetterr.Models
{
	public class Server : IServer
	{
		private Dictionary<int, string> messages;
		private int id;

		public Server()
		{
			this.messages = new Dictionary<int, string>();
			this.id = 1;
		}

		public void SaveToServer(string message)
		{
			this.messages.Add(id, message);
			this.id++;
		}
	}
}

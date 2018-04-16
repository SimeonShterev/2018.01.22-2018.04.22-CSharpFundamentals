using System;
using System.Collections.Generic;
using System.Text;
using Twetterr.Contracts;

namespace Twetterr.Models
{
	public class Twetter : IMessage
	{
		private string tweet;

		public Twetter(string message)
		{
			this.tweet = message;
			if(string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentNullException("Message should be contain at least one char");
			}
		}

		public string RetrieveMessage()
		{
			return this.tweet;
		}
	}
}

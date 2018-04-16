using System;
using System.Collections.Generic;
using System.Text;

namespace Twetterr.Contracts
{
    public interface IClient
    {
		void RecieveMessage(IMessage tweet);

		void WriteOnConsole(string message);

		void SendToServer(string message);
    }
}

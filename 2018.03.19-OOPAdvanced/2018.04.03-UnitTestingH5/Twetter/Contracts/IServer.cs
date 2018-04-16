using System;
using System.Collections.Generic;
using System.Text;

namespace Twetterr.Contracts
{
    public interface IServer
    {
		void SaveToServer(string message);
    }
}

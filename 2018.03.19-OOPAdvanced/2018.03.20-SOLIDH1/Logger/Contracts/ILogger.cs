using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface ILogger
    {
		void Log(IError error);
    }
}

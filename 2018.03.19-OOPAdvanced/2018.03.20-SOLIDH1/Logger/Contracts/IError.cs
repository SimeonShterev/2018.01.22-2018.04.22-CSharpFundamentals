using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IError
    {
		DateTime DateTime { get; }

		ReportLevel Level { get; }

		string Message { get; }
    }
}

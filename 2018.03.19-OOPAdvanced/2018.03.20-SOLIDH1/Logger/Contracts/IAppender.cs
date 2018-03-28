using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
		ILayout Layout { get; }

		ReportLevel Level { get; }

		void Append(IError error);
    }
}

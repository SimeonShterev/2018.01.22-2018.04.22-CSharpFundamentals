using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
	public class Logger : ILogger
	{
		ICollection<IAppender> appenders;

		public Logger(ICollection<IAppender> appenders)
		{
			this.appenders = appenders;
		}

		public void Log(IError error)
		{
			foreach (var appender in this.appenders)
			{
				if(appender.Level<=error.Level)
				{
					appender.Append(error);
				}
			}
		}
	}
}

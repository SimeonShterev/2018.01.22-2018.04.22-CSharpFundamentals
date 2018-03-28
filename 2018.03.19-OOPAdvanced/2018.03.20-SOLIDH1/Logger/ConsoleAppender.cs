using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleAppender : IAppender
    {
		public ConsoleAppender(ILayout layout, ReportLevel level)
		{
			this.Level = level;
			this.Layout = layout;
		}

		public ILayout Layout { get; }

		public ReportLevel Level { get; }

		public void Append(IError error)
		{
			string formateredError = this.Layout.FormatError(error);
			Console.WriteLine(formateredError);
		}
    }
}

using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
									//date - level - message
		private const string Format = "{0} - {1} - {2}";

		public SimpleLayout() { }

		public string FormatError(IError error)
		{
			return string.Format(Format, error.DateTime, error.Level, error.Message);
		}
	}
}

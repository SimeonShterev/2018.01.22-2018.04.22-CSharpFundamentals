using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class SimpleLayout
    {


		public string DateTime { get; set; }

		public string ReportLevel { get; set; }

		public string Message { get; set; }

		public override string ToString()
		{
			return $"";
		}
	}
}

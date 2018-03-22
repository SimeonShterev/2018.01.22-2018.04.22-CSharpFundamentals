using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class ConsoleAppender
    {
		public void AppendLayoutToConsole(SimpleLayout simpleLayout)
		{
			Console.WriteLine(simpleLayout);
		}
    }
}

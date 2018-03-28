using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    class FileAppender
    {
		public FileAppender(SimpleLayout simpleLayout)
		{

		}

		public void AppendLayoutToFile(SimpleLayout simpleLayout)
		{
			File.AppendAllText("../../fileAppender.txt", simpleLayout.ToString());
		}
    }
}

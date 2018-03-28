using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
	public class LogFile : ILogFile
	{
		public LogFile(string path, int size)
		{
			this.Path = path;
			this.Size = size;
		}

		public string Path { get; }

		public int Size { get; }

		public void WriteToFile()
		{
		}
	}
}

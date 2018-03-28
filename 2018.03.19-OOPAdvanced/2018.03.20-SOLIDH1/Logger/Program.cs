using Logger.Contracts;
using System;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
			ILayout layout = new SimpleLayout();
			IAppender appender = new ConsoleAppender(layout, ReportLevel.INFO);
			ILogger logger = new Logger(new IAppender[] { appender });

			DateTime date = DateTime.Parse("3/20/2015 03:08:11 PM");
			IError error = new Error(date, ReportLevel.CRITICAL, "Crit Error");
			logger.Log(error);


			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{

			}

			string input;
			List<string> list = new List<string>();
			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split('|');
				ReportLevel level = (ReportLevel)(Enum.Parse(typeof(ReportLevel), commandArgs[0]));
				DateTime dateTime = DateTime.Parse(commandArgs[1]);
				string message = commandArgs[2];

				IError error = new Error(dateTime, level, message);
				ILayout layout = new SimpleLayout();
				string output = layout.FormatError(error);

			}
		}
	}
}

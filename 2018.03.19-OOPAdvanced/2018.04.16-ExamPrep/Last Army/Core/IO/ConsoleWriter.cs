using System;
using System.Text;

public class ConsoleWriter : IWriter
{
	private StringBuilder builder;

	public ConsoleWriter()
	{
		this.builder = new StringBuilder();
	}

	public void Append(string text)
	{
		this.builder.AppendLine(text.Trim());
	}

	public void PrintResult()
	{
		Console.WriteLine(this.builder.ToString().Trim());
	}

	public void WriteLine(string output)
	{
		Console.WriteLine(output);
	}
}
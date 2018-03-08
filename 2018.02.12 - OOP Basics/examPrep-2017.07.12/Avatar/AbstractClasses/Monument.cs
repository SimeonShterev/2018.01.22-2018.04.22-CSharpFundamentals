using System;
using System.Collections.Generic;
using System.Text;


public abstract class Monument : IMonuments
{
	public Monument(string name)
	{
		this.Name = name;
	}

	public string Name { get; set; }

	public override string ToString()
	{
		string result = $"Monument: {this.Name}, ";
		return result;
	}
}
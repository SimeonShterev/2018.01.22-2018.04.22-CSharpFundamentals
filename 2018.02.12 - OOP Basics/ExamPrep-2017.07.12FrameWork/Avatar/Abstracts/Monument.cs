using System;
using System.Collections.Generic;
using System.Text;


public abstract class Monument : Unit, IMonuments
{
	public Monument(string name, int affinity) : base(name)
	{
		this.Affinity = affinity;
	}

	public int Affinity { get; private set; }

	public override string ToString()
	{
		string result = $" Monument: {this.Name}, ";
		return result;
	}
}
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Unit
{
	public Unit(string name)
	{
		this.Name = name;
	}

	public string Name { get; private set; }
}
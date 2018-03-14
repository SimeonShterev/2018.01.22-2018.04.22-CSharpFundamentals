using System;
using System.Collections.Generic;
using System.Text;

public abstract class Unit
{
	public Unit(string id)
	{
		this.Id = id;
	}

	public string Id { get; private set; }
}
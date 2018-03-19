using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center
{
	protected List<Animal> animalList;

	protected Center(string name)
	{
		this.Name = name;
		this.animalList = new List<Animal>();
	}

	public string Name { get; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
	protected Animal(string name, int age)
	{
		this.Name = name;
		this.Age = age;
	}

	public string Name { get; }

	public int Age { get; }

	public bool IsClean { get; private set; }

	public void Clean()
	{
		this.IsClean = true;
	}

	public void AddToAdoptionCenter(string adoptionCenterName)
	{
		
	}
}
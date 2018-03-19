using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Animal
{
	public Cat(string name, int age, int intelligence) 
		: base(name, age)
	{
		this.Intelligence = intelligence;
	}

	public int Intelligence { get; }
}
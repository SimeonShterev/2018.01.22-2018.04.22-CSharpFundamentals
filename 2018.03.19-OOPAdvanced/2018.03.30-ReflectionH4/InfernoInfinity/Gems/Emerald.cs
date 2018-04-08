using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
	private const int DefaultStrenght = 1;
	private const int DefaultAgility = 4;
	private const int DefaultVitality = 9;

	public Emerald(GemClarity gemClarity) 
		: base(gemClarity, DefaultStrenght, DefaultAgility, DefaultVitality)
	{
	}
}
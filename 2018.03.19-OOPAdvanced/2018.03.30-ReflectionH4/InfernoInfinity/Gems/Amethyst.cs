using System;
using System.Collections.Generic;
using System.Text;

public class Amethyst : Gem
{
	private const int DefaultStrenght = 2;
	private const int DefaultAgility = 8;
	private const int DefaultVitality = 4;

	public Amethyst(GemClarity gemClarity) 
		: base(gemClarity, DefaultStrenght, DefaultAgility, DefaultVitality)
	{
	}
}
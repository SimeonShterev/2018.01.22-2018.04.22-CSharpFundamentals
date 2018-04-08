using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{
	private const int DefaultStrenght = 7;
	private const int DefaultAgility = 2;
	private const int DefaultVitality = 5;

	public Ruby(GemClarity gemClarity) 
		: base(gemClarity, DefaultStrenght, DefaultAgility, DefaultVitality)
	{
	}
}
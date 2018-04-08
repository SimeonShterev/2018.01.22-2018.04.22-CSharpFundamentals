using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
	private int strenght;
	private int agility;
	private int vitality;
	private GemClarity gemClarity;

	public Gem(GemClarity gemClarity,int strenght, int agility, int vitality)
	{
		this.Strenght = strenght + (int)gemClarity;
		this.Agility = agility + (int)gemClarity;
		this.Vitality = vitality + (int)gemClarity;
	}

	public int Strenght
	{
		get
		{
			return this.strenght;
		}
		private set
		{
			this.strenght = value;
		}
	}

	public int Agility
	{
		get
		{
			return this.agility;
		}
		private set
		{
			this.agility = value;
		}
	}

	public int Vitality
	{
		get
		{
			return this.vitality;
		}
		private set
		{
			this.vitality = value;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Characters;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Factories
{
	public class CharacterFactory
	{
		public Character CreateCharacter(string[] args)
		{
			string type = args[1];
			string name = args[2];
			object faction = Enum.Parse(typeof(Faction), args[0]);
			switch (type)
			{
				case "Warrior":
					return new Warrior(name, (Faction)faction);
				case "Cleric":
					return new Cleric(name, (Faction)faction);
				default:
					throw new ArgumentException("exception in the characterFactory");
			}
		}
	}
}

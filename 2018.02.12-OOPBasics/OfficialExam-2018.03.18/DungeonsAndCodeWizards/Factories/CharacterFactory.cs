using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Characters;
using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
	public class CharacterFactory
	{
		public Character CreateCharacter(string faction, string type, string name)
		{
			bool validFaction = Enum.TryParse(typeof(Faction), faction, out object outFaction);
			if (!validFaction)
			{
				throw new ArgumentException(string.Format(ErrorMessages.InvalidFaction, faction));
			}
			switch (type)
			{
				case "Warrior":
					return new Warrior(name, (Faction)outFaction);
				case "Cleric":
					return new Cleric(name, (Faction)outFaction);
				default:
					throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacterType, type));
			}
		}
	}
}

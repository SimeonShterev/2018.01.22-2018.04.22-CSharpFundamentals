using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Factories
{
    public class CharacterFactory
    {
		public Character CreateCharacter(string factionAsString, string charType, string name)
		{
			// no reflection allowed
			if (!Enum.TryParse<Faction>(factionAsString, out Faction faction))
			{
				throw new ArgumentException(string.Format(Consts.InvalidFaction, factionAsString));
			}

			if (charType!="Warrior" && charType!="Cleric")
			{
				throw new ArgumentException(string.Format(Consts.InvalidCharType, charType));
			}

			Assembly assembly = Assembly.GetCallingAssembly();
			Type type = assembly.GetTypes().First(t => t.Name == charType);

			Character character = (Character)Activator.CreateInstance(type, name, faction);
			return character;
		}
    }
}

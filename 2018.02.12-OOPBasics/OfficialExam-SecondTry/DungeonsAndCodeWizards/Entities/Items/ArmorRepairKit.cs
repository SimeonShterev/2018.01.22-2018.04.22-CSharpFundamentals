using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
		private const int weigth = 10;

		public ArmorRepairKit()
			: base(weigth) { }

		public override void AffectCharacter(Character character)
		{
			base.AffectCharacter(character);
			character.Armor = character.BaseArmor;
		}
	}
}

using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Items
{
	public class ArmorRepairKit : Item
	{
		private const int ArmorKitWeight = 10;

		public ArmorRepairKit() 
			: base(ArmorKitWeight)
		{
		}

		public override string Name => "ArmorRepairKit";

		public override void AffectCharacter(Character character)
		{
			character.Armor = character.BaseArmor; 
		}
	}
}

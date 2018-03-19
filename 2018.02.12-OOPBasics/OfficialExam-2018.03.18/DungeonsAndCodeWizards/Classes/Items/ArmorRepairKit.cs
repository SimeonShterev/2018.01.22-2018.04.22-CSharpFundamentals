using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Items
{
	public class ArmorRepairKit : Item
	{
		public ArmorRepairKit() 
			: base(10)
		{
		}

		public override string Name => "ArmorRepairKit";

		public override void AffectCharacter(Character character)
		{
			character.Armor += character.BaseArmor;
		}
	}
}

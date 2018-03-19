using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Items
{
	public class HealthPotion : Item
	{
		public HealthPotion() 
			: base(5)
		{
		}

		public override string Name => "HealthPotion";

		public override void AffectCharacter(Character character)
		{
			base.AffectCharacter(character);
			character.Health += 20;
		}
	}
}

using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Items
{
	public class HealthPotion : Item
	{
		private const int healthPotionWeight = 5;

		public HealthPotion() 
			: base(healthPotionWeight)
		{
		}
		public override string Name => "HealthPotion";

		public override void AffectCharacter(Character character)
		{
			character.Health += 20;
		}
	}
}

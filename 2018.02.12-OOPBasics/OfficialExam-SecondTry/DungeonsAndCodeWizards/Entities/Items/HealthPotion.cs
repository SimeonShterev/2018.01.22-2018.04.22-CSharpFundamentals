using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
	public class HealthPotion : Item
	{
		private const int weigth = 5;

		public HealthPotion()
			: base(weigth) { }

		public override void AffectCharacter(Character character)
		{
			base.AffectCharacter(character);
			character.Health += 20;
		}
	}
}

using DungeonsAndCodeWizards.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Classes.Items
{
	public class PoisonPotion : Item
	{
		public PoisonPotion()
			: base(5)
		{
		}

		public override string Name => "PoisonPotion";

		public override void AffectCharacter(Character character)
		{
			character.Health -= 20;
		}
	}
}

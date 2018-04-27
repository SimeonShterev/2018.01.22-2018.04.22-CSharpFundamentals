﻿using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
		private const int weigth = 5;

		public PoisonPotion()
			: base(weigth) { }

		public override void AffectCharacter(Character character)
		{
			base.AffectCharacter(character);
			character.Health -= 20;
		}
	}
}

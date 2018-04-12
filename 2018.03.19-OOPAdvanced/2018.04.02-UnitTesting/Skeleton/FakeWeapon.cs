using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
	public class FakeWeapon : IWeapon
	{
		private int attack;
		private int durability;

		public FakeWeapon()
		{
			this.attack = 10;
			this.durability = 10;
		}

		public int AttackPoints => this.attack;

		public int DurabilityPoints => this.durability;

		public void Attack(ITarget target)
		{
			if(this.durability<=0)
			{
				throw new InvalidOperationException("FakeWeapon is broken");
			}
			target.TakeAttack(this.attack);
			this.durability -= 1;
		}
	}
}

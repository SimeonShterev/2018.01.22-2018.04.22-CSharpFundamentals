using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeTarget : ITarget
    {
		private int experience;

		public FakeTarget()
		{
			this.experience = 12;
		}

		public int Health => 0;

		public void TakeAttack(int attackPoints)
		{
		}

		public int GiveExperience()
		{
			return this.experience;
		}

		public bool IsDead()
		{
			return true;
		}
	}
}

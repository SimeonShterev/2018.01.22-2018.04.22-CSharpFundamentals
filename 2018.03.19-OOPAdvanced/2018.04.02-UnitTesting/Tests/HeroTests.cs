using Moq;
using NUnit.Framework;
using Skeleton;
using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class HeroTests
    {
		[Test]
		public void HeroGainsXPFromDeadTarget()
		{
			Mock<ITarget> targetMock = new Mock<ITarget>();
			targetMock.Setup(t => t.IsDead()).Returns(true);
			targetMock.Setup(t => t.GiveExperience()).Returns(30);
			Mock<IWeapon> weaponMock = new Mock<IWeapon>();
			Hero hero = new Hero("Simo", weaponMock.Object);

			hero.Attack(targetMock.Object);
			int herosXP = hero.Experience;

			Assert.That(hero.Experience,Is.EqualTo(30), "Target doesn't give expected XP");
		}
    }
}

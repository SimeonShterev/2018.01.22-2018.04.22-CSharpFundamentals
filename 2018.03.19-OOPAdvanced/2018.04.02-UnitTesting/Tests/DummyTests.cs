using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class DummyTests
{
	private Dummy dummy;
	private Axe axe;

	[SetUp]
	public void InitialiseUnits()
	{
		this.axe = new Axe(10, 10);
		this.dummy = new Dummy(10, 10);
	}

	[Test]
	public void DummyLosesHealthAfterAttack()
	{
		Axe axe = new Axe(2, 10);
		Dummy dummy = new Dummy(10, 10);

		int dummyInitialHealth = dummy.Health;
		axe.Attack(dummy);

		Assert.That(dummy.Health, Is.EqualTo(dummyInitialHealth - axe.AttackPoints),"Unexpected dummmy health");
	}

	[Test]
	public void DeadDummyThrowsException()
	{
		Axe axe = new Axe(2, 10);
		Dummy dummy = new Dummy(2, 3);

		axe.Attack(dummy);

		Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message, "Dummy is dead.");
	}

	[Test]
	public void DeadDummyGiveXP()
	{
		int dummyInitialXP = 12;
		Axe axe = new Axe(10, 10);
		Dummy dummy = new Dummy(5, dummyInitialXP);

		axe.Attack(dummy);
		int expectedXPRecieved = dummy.GiveExperience();

		Assert.That(expectedXPRecieved==dummyInitialXP, "Dead dummy doesn't give XP");
	}

	[Test]
	public void AliveDummyCannotGiveXP()
	{
		Axe axe = new Axe(2, 10);
		Dummy dummy = new Dummy(12, 12);

		axe.Attack(dummy);

		Assert.That(()=>dummy.GiveExperience(), Throws.InvalidOperationException.With.Message, "Target is dead.");
	}
}
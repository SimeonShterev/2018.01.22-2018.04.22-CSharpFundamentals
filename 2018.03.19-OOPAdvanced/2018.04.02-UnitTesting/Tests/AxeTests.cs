using NUnit.Framework;
using System;

public class AxeTests
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
	public void CheckAxeLoseDurabilityAfterAttack()
	{
		//Arrange
		//Axe axe = new Axe(10, 10);
		//Dummy dummy = new Dummy(10, 10);

		//Act
		int reducedDurability = axe.DurabilityPoints - 1;
		axe.Attack(dummy);

		//Assert
		Assert.AreEqual(reducedDurability, axe.DurabilityPoints);
	}

	[Test]
	public void CanBrokenAxeAttack()
	{
		Axe axe = new Axe(2, 1);
		Dummy dummy = new Dummy(10, 10);

		axe.Attack(dummy);

		Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
	}
}
// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
	//using FestivalManager.Core.Controllers;
	//using FestivalManager.Core.Controllers.Contracts;
	//using FestivalManager.Entities;
	//using FestivalManager.Entities.Contracts;
	//using FestivalManager.Entities.Instruments;
	//using FestivalManager.Entities.Sets;
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
		public void TestSetControlerDidNotPerformMessage()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet set = new Medium("Set2");
			stage.AddSet(set);

			string actualMessage = setController.PerformSets();
			string expectedMessage = "1. Set2:" + Environment.NewLine + "-- Did not perform";

			Assert.That(actualMessage, Is.EqualTo(expectedMessage));
		}

		[Test]
		public void TestSetControlerValidMessage()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet set = new Medium("Set2");
			stage.AddSet(set);

			IPerformer performer = new Performer("Gosho", 20);
			IInstrument instrument = new Drums();
			performer.AddInstrument(instrument);

			ISong song = new Song("DoUtre", new TimeSpan(0, 4, 20));
			set.AddPerformer(performer);
			set.AddSong(song);

			string actualMessage = setController.PerformSets();
			string expectedMessage = "1. Set2:" + Environment.NewLine + "-- 1. DoUtre (04:20)" + Environment.NewLine + "-- Set Successful";

			double instrumentWearLevel = instrument.Wear;

			Assert.That(actualMessage, Is.EqualTo(expectedMessage));
			Assert.That(instrumentWearLevel, Is.EqualTo(80d));
		}

		[Test]
		public void TestSetControlerWearDown()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet set = new Medium("Set2");
			stage.AddSet(set);

			IPerformer performer = new Performer("Gosho", 20);
			IInstrument instrument = new Drums();
			performer.AddInstrument(instrument);

			ISong song = new Song("DoUtre", new TimeSpan(0, 4, 20));
			set.AddPerformer(performer);
			set.AddSong(song);

			setController.PerformSets();
			double instrumentWearLevel = instrument.Wear;

			Assert.That(instrumentWearLevel, Is.EqualTo(80d));
		}
	}
}
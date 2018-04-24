// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
	using FestivalManager.Core.Controllers;
	using FestivalManager.Core.Controllers.Contracts;
	using FestivalManager.Entities;
	using FestivalManager.Entities.Contracts;
	using FestivalManager.Entities.Instruments;
	using FestivalManager.Entities.Sets;
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class SetControllerTests
	{
		[Test]
		public void TestPerformSetsDidNotPerformMessage()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet longset = new Long("LongSet");
			stage.AddSet(longset);

			string expectedOutput = "1. LongSet:" + Environment.NewLine + "-- Did not perform";
			Assert.That(() => setController.PerformSets(), Is.EqualTo(expectedOutput));
		}

		[Test]
		public void TestPerformSetsSetSuccessfulMessage()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet longset = new Long("LongSet");
			ISong song = new Song("Pesho", new TimeSpan(0, 2, 3));
			IPerformer performer = new Performer("Gosho", 20);
			IInstrument instrument = new Drums();

			performer.AddInstrument(instrument);
			longset.AddPerformer(performer);
			longset.AddSong(song);
			stage.AddSet(longset);

			ISet longset1 = new Long("LongSet1");
			ISong song1 = new Song("Pesho1", new TimeSpan(0, 2, 3));
			IPerformer performer1 = new Performer("Gosho1", 20);
			IPerformer performer2 = new Performer("Gosho2", 20);
			IInstrument instrument1 = new Drums();

			performer1.AddInstrument(instrument1);
			performer2.AddInstrument(instrument1);
			longset1.AddPerformer(performer1);
			longset1.AddPerformer(performer2);
			longset1.AddSong(song1);
			stage.AddSet(longset1);

			string expectedOutput = "1. LongSet1:" + Environment.NewLine +
							"-- 1. Pesho1 (02:03)" + Environment.NewLine +
							"-- Set Successful" + Environment.NewLine +
									"2. LongSet:" + Environment.NewLine +
							"-- 1. Pesho (02:03)" + Environment.NewLine +
							"-- Set Successful";

			Assert.That(() => setController.PerformSets(), Is.EqualTo(expectedOutput));
		}

		[Test]
		public void TestPerformSetsSet()
		{
			IStage stage = new Stage();
			ISetController setController = new SetController(stage);

			ISet longset = new Long("LongSet");
			ISong song = new Song("Pesho", new TimeSpan(0, 2, 3));
			IPerformer performer = new Performer("Gosho", 20);
			IInstrument instrument = new Drums();

			performer.AddInstrument(instrument);
			longset.AddPerformer(performer);
			longset.AddSong(song);
			stage.AddSet(longset);

			string expectedOutput = "1. LongSet:" + Environment.NewLine + "-- 1. Pesho (02:03)" + Environment.NewLine + "-- Set Successful";
			Assert.That(() => setController.PerformSets(), Is.EqualTo(expectedOutput));
		}

		[Test]
		public void Test()
		{
			Assert.Pass();
		}
	}
}
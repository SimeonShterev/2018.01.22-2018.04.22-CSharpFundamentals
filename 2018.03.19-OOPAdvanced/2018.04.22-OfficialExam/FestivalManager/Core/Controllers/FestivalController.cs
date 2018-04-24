namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
	using FestivalManager.Constants;
	using FestivalManager.Entities.Factories;
	using FestivalManager.Entities.Factories.Contracts;

	public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private IInstrumentFactory instrumentFactory;
		private IPerformerFactory performerFactory;
		private ISetFactory setFactory;
		private ISongFactory songFactory;

		private IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

			this.setFactory = new SetFactory();
			this.performerFactory = new PerformerFactory();
			this.instrumentFactory = new InstrumentFactory();
			this.songFactory = new SongFactory();
		}

		public string RegisterSet(string[] args)
		{
			string name = args[0];
			string type = args[1];

			ISet set = this.setFactory.CreateSet(name, type);
			this.stage.AddSet(set);

			return string.Format(Consts.SetRegistered, type);
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);
			string[] instruments = args.Skip(2).ToArray();

			foreach (var instrumentName in instruments)
			{
				IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentName);
				performer.AddInstrument(instrument);
			}
			this.stage.AddPerformer(performer);

			return string.Format(Consts.PerformerRegistered, name);
		}

		public string RegisterSong(string[] args)
		{
			string name = args[0];

			int[] songLengthArr = args[1].Split(':').Select(int.Parse).ToArray();
			int hours = 0;
			int minutes = songLengthArr[0];
			int seconds = songLengthArr[1];
			TimeSpan songLength = new TimeSpan(hours, minutes, seconds);

			ISong song = this.songFactory.CreateSong(name, songLength);
			this.stage.AddSong(song);

			return string.Format(Consts.SongRegistered, name, songLength.ToString(TimeFormat));
		}

		public string AddSongToSet(string[] args)
		{
			string songName = args[0];
			string setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(Consts.SetInvalid);
			}
			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException(Consts.SongInvalid);
			}

			ISong song = this.stage.GetSong(songName);
			this.stage.Sets.First(s => s.Name == setName).AddSong(song);

			return string.Format(Consts.SongAddetToSet, songName, song.Duration.ToString(TimeFormat), setName);
		}

		public string AddPerformerToSet(string[] args)
		{
			string performerName = args[0];
			string setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException(Consts.PerformerInvalid);
			}
			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(Consts.SetInvalid);
			}

			IPerformer performer = this.stage.GetPerformer(performerName);
			this.stage.Sets.First(s => s.Name == setName).AddPerformer(performer);

			return string.Format(Consts.PerformerAddedToSet, performerName, setName);
		}

		public string RepairInstruments(string[] args)
		{
			int counter = 0;
			foreach (var performer in this.stage.Performers)
			{
				foreach (var instrument in performer.Instruments)
				{
					if (instrument.Wear < 100)
					{
						instrument.Repair();
						counter++;
					}
				}
			}

			return string.Format(Consts.RepairedInstruments, counter);
		}

		public string ProduceReport()
		{
			StringBuilder builder = new StringBuilder();

			int minutes = this.stage.Sets.Sum(s => (int)s.ActualDuration.TotalMinutes);
			int seconds = this.stage.Sets.Sum(s => s.ActualDuration.Seconds);

			builder.AppendLine(Consts.Result);
			builder.AppendLine(string.Format(Consts.TotalLength, minutes, seconds));

			foreach (var set in this.stage.Sets)
			{
				int setMinutes = (int)set.ActualDuration.TotalMinutes;
				int setSeconds = set.ActualDuration.Seconds;

				builder.AppendLine($"--{set.Name} ({setMinutes:00}:{setSeconds:00}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					builder.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
				{
					builder.AppendLine("--No songs played");
				}
				else
				{
					builder.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
					{
						builder.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
					}
				}
			}

			return builder.ToString().Trim();
		}
	}
}
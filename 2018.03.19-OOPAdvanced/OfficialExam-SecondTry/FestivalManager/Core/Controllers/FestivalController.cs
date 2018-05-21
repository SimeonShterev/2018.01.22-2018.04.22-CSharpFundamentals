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

		private IStage stage;

		private ISetFactory setFactory;
		private ISongFactory songFactory;
		private IPerformerFactory performerFactory;
		private IInstrumentFactory instrumentFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

			this.setFactory = new SetFactory();
			this.songFactory = new SongFactory();
			this.performerFactory = new PerformerFactory();
			this.instrumentFactory = new InstrumentFactory();

		}

		public string RegisterSet(string[] args)
		{
			string name = args[0];
			string type = args[1];

			ISet set = this.setFactory.CreateSet(name, type);
			this.stage.AddSet(set);

			return string.Format(Consts.RegisteredSet, type);
		}

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instrumentNames = args.Skip(2).ToArray();

			IInstrument[] instruments = instrumentNames
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
			string name = args[0];
			string[] timeAsStringArray = args[1].Split(':');
			int minutes = int.Parse(timeAsStringArray[0]);
			int seconds = int.Parse(timeAsStringArray[1]);
			TimeSpan duration = new TimeSpan(0, minutes, seconds);

			ISong song = this.songFactory.CreateSong(name, duration);
			this.stage.AddSong(song);

			return string.Format(Consts.RegisteredSong, song.Name, duration.ToString(TimeFormat));
		}

		public string AddSongToSet(string[] args)
		{
			string songName = args[0];
			string setName = args[1];

			if(!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(Consts.InvalidSet);
			}
			if(!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException(Consts.InvalidSong);
			}

			ISet set = this.stage.GetSet(setName);
			ISong song = this.stage.GetSong(songName);

			set.AddSong(song);

			return string.Format(Consts.SongAddedToSet, song.Name, song.Duration.ToString(TimeFormat), set.Name);
		}

		public string AddPerformerToSet(string[] args)
		{
			string performerName = args[0];
			string setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException(Consts.InvalidPerformer);
			}
			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(Consts.InvalidSet);
			}

			IPerformer performer = this.stage.GetPerformer(performerName);
			ISet set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return string.Format(Consts.PerformerAddedToSet, performer.Name, set.Name);
		}

		public string RepairInstruments(string[] args)
		{
			IInstrument[] instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

		public string ProduceReport()
		{
			StringBuilder builder = new StringBuilder();

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
			int festivalMinutes = (int)totalFestivalLength.TotalMinutes;
			int festivalSeconds = totalFestivalLength.Seconds;

			builder.AppendLine("Results:");
			builder.AppendLine($"Festival length: {festivalMinutes:d2}:{festivalSeconds:d2}");

			foreach (var set in this.stage.Sets)
			{
				int setMinutes = (int)set.ActualDuration.TotalMinutes;
				int setSeconds = set.ActualDuration.Seconds;

				builder.AppendLine($"--{set.Name} ({setMinutes:d2}:{setSeconds:d2}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					builder.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
					builder.AppendLine("--No songs played");
				else
				{
					builder.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
					{
						int songMinutes = (int)song.Duration.TotalMinutes;
						int songSeconds = song.Duration.Seconds;

						builder.AppendLine($"----{song.Name} ({songMinutes:d2}:{songSeconds:d2})");
					}
				}
			}

			return builder.ToString().Trim();
		}
	}
}
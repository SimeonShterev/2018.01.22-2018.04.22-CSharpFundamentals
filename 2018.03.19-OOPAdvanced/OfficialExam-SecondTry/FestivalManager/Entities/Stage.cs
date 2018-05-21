namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;

	public class Stage : IStage
	{
		private List<ISet> sets;
		private List<ISong> songs;
		private List<IPerformer> performers;

		public Stage()
		{
			this.sets = new List<ISet>();
			this.songs = new List<ISong>();
			this.performers = new List<IPerformer>();
		}

		public IReadOnlyCollection<ISet> Sets => this.sets;

		public IReadOnlyCollection<ISong> Songs => this.songs;

		public IReadOnlyCollection<IPerformer> Performers => this.performers;

		public void AddPerformer(IPerformer performer)
		{
			this.performers.Add(performer);
		}

		public void AddSet(ISet set)
		{
			this.sets.Add(set);
		}

		public void AddSong(ISong song)
		{
			this.songs.Add(song);
		}

		public IPerformer GetPerformer(string name)
		{
			return this.performers.First(p => p.Name == name);
		}

		public ISet GetSet(string name)
		{
			return this.sets.First(s => s.Name == name);
		}

		public ISong GetSong(string name)
		{
			return this.songs.First(s => s.Name == name);
		}

		public bool HasPerformer(string name)
		{
			IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);
			return performer == null ? false : true;
		}

		public bool HasSet(string name)
		{
			ISet set = this.sets.FirstOrDefault(s => s.Name == name);
			return set == null ? false : true;
		}

		public bool HasSong(string name)
		{
			ISong song = this.songs.FirstOrDefault(s => s.Name == name);
			return song == null ? false : true;
		}
	}
}

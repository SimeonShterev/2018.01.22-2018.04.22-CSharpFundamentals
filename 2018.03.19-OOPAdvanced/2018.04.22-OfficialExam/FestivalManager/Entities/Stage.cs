namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;

	public class Stage : IStage // perfect
	{
		private IList<IPerformer> performers;
		private IList<ISong> songs;
		private IList<ISet> sets;

		public Stage()
		{
			this.performers = new List<IPerformer>();
			this.songs = new List<ISong>();
			this.sets = new List<ISet>();
		}

		public IReadOnlyCollection<ISet> Sets => this.sets.ToArray();

		public IReadOnlyCollection<ISong> Songs => this.songs.ToArray();

		public IReadOnlyCollection<IPerformer> Performers => this.performers.ToArray();

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
			IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);

			return performer;
		}

		public ISet GetSet(string name)
		{
			ISet set = this.sets.FirstOrDefault(s => s.Name == name);

			return set;
		}

		public ISong GetSong(string name)
		{
			ISong song = this.songs.FirstOrDefault(s => s.Name == name);

			return song;
		}

		public bool HasPerformer(string name)
		{
			IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);
			if(performer==null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool HasSet(string name)
		{
			ISet set = this.sets.FirstOrDefault(s => s.Name == name);
			if (set == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool HasSong(string name)
		{
			ISong song = this.songs.FirstOrDefault(s => s.Name == name);
			if (song == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}

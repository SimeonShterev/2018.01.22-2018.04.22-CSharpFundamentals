namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
			Type type = Assembly.GetCallingAssembly().GetTypes().First(c => c.Name == "Song");

			ISong song = (ISong)Activator.CreateInstance(type, name, duration);
			return song;
		}
	}
}
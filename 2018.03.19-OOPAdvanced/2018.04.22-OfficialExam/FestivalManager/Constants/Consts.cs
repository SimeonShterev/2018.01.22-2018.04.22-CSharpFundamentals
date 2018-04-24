using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Constants
{
    public static class Consts
    {
		public const string SongInvalid = "Invalid song provided";
		public const string SetInvalid = "Invalid set provided";
		public const string PerformerInvalid = "Invalid performer provided";

		public const string SongRegistered = "Registered song {0} ({1})";
		public const string SetRegistered = "Registered {0} set";

		public const string SongAddetToSet = "Added {0} ({1}) to {2}";
		public const string PerformerAddedToSet = "Added {0} to {1}";

		public const string SongOverLimit = "Song is over the set limit!";
		public const string PerformerRegistered = "Registered performer {0}";
		public const string RepairedInstruments = "Repaired {0} instruments";

		public const string Error = "ERROR: {0}";


		public const string Result = "Results:";
		public const string TotalLength = "Festival length: {0:00}:{1:00}";
	}
}

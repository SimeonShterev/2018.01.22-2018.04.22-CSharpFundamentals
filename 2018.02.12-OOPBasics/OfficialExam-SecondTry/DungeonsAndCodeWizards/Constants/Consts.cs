using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Constants
{
	public static class Consts
	{
		public const string FullBag = "Bag is full!";
		public const string EmptyBag = "Bag is empty!";

		public const string NotSuchItem = "No item with name {0} in bag!";
		public const string ItemAdded = "{0} added to pool.";

		public const string DeadCharacter = "Must be alive to perform this action!";
		public const string NameNull = "Name cannot be null or whitespace!";

		public const string SelfAttack = "Cannot attack self!";
		public const string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";
		public const string HealEnemy = "Cannot heal enemy character!";

		public const string InvalidFaction = "Invalid faction \"{0}\"!";
		public const string InvalidCharType = "Invalid character type \"{0}\"!";

		public const string CharJoined = "{0} joined the party!";
		public const string InvalidItem = "Invalid item \"{0}\"!";
		public const string CharNotFound = "Character {0} not found!";
		public const string PoolEmpty = "No items left in pool!";
		public const string SuccessfulPickedUp = "{0} picked up {1}!";
		public const string CharUsedItem = "{0} used {1}.";
		public const string CharUsedItemOn = "{0} used {1} on {2}.";
		public const string CharGaveItem = "{0} gave {1} {2}.";
		public const string Stats = "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";
		public const string CanNotAttack = "{0} cannot attack!";
		public const string CanNotHeal = "{0} cannot heal!";
		public const string DeadChar = "{0} is dead!";
		public const string Rest = "{0} rests ({1} => {2})";
		
		public const string FinalStats = "Final stats:";
	}
}

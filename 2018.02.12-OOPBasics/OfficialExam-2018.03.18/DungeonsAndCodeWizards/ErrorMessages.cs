using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public static class ErrorMessages
	{
		public static string Dead = "Must be alive to perform this action!";

		public static string InvalidName = "Name cannot be null or whitespace!";

		public static string InvalidType = "Invalid character type {0}!";

		public static string InvalidFaction = "Invalid faction {0}!";

		public static string InvalidItem = "Invalid item {0}";

		public static string CharacterDoesntExist = "Character {0} not found!";

		public static string NoItemsInPool = "No items left in pool!";

		public static string FullBag = "Bag is full!";

		public static string EmptyBag = "Bag is empty!";

		public static string NoSuchItemInBag = "No item with name {0} in bag!";

		public static string FriendlyFire = "Friendly fire! Both characters are from {0} faction!";

		public static string Self = "Cannot attack self!";

		public static string NotAbleToAttack = "";
    }
}

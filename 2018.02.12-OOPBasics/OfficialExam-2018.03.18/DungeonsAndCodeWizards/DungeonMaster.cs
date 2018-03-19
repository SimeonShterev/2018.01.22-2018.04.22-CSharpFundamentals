using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Characters;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public class DungeonMaster
	{
		private CharacterFactory characterFactory;
		private ItemFactory itemFactory;
		private List<Character> charactersList;
		private List<Item> itemsList;

		public DungeonMaster()
		{
			this.characterFactory = new CharacterFactory();
			this.itemFactory = new ItemFactory();
			this.charactersList = new List<Character>();
			this.itemsList = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string name = args[2];
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(ErrorMessages.InvalidName);
			}
			string type = args[1];
			if (type != "Warrior" || type != "Cleric")
			{
				throw new ArgumentException(string.Format(ErrorMessages.InvalidType, type));
			}
			string faction = args[0];
			if (faction != "CSharp" || faction != "Java")
			{
				throw new ArgumentException(string.Format(ErrorMessages.InvalidFaction, faction));
			}
			Character character = this.characterFactory.CreateCharacter(args);
			charactersList.Add(character);
			return $"{character.Name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if (itemName != "HealthPotion" || itemName != "PoisonPotion")
			{
				throw new ArgumentException(string.Format(ErrorMessages.InvalidItem));
			}
			Item item = this.itemFactory.CreateItem(args);
			itemsList.Add(item);
			return $"{args[1]} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			Character character = charactersList.FirstOrDefault(c => c.Name == args[0]);
			if (!character.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (character == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (!itemsList.Any())
			{
				throw new InvalidOperationException(ErrorMessages.NoItemsInPool);
			}
			Item item = itemsList.Last();
			character.ReceiveItem(item);
			return $"“{character.Name} picked up {item.Name}!”";
		}

		public string UseItem(string[] args)
		{
			Character character = charactersList.FirstOrDefault(c => c.Name == args[0]);
			if (!character.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (character == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (character.Bag.CheckForItem(args[1]))
			{
				throw new ArgumentException(ErrorMessages.NoSuchItemInBag);
			}
			Item item = itemsList.Find(i => i.Name == args[1]);
			character.UseItem(item);
			switch (item.Name)
			{
				case "HealthPotion":
					item.AffectCharacter(character);
					break;
				case "ArmorRepairKit":
					item.AffectCharacter(character);
					break;
				case "PoisonPotion":
					item.AffectCharacter(character);
					break;
				default:
					// throw ex
					break;
			}
			return $"{character.Name} used {item.Name}.";
		}

		public string UseItemOn(string[] args)
		{
			string giverName = args[0];
			string reciverName = args[1];

			Character giver = this.charactersList.Find(c => c.Name == giverName);
			if (giver == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, reciverName));
			}

			//if (!giver.IsAlive)
			//{
			//	throw new ArgumentException(ErrorMessages.Dead);
			//}
			//if (!reciever.IsAlive)
			//{
			//	throw new ArgumentException(ErrorMessages.Dead);
			//}
			Character reciever = charactersList.FirstOrDefault(c => c.Name == reciverName);
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, reciverName));
			}

			if (giver.Bag.CheckForItem(args[1]))
			{
				throw new ArgumentException(ErrorMessages.NoSuchItemInBag);
			}
			Item item = itemsList.Find(i => i.Name == args[1]);
			giver.UseItemOn(item, reciever);
			return $"{giver.Name} used {item.Name} on {reciever.Name}.";
		}

		public string GiveCharacterItem(string[] args)
		{
			Character giver = charactersList.FirstOrDefault(c => c.Name == args[0]);
			Character reciever = charactersList.FirstOrDefault(c => c.Name == args[0]);
			if (!giver.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (!reciever.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (giver == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (giver.Bag.CheckForItem(args[1]))
			{
				throw new ArgumentException(ErrorMessages.NoSuchItemInBag);
			}
			Item item = itemsList.Find(i => i.Name == args[1]);
			giver.UseItemOn(item, reciever);
			switch (item.Name)
			{
				case "HealthPotion":
					giver.GiveCharacterItem(item, reciever);
					break;
				case "ArmorRepairKit":
					giver.GiveCharacterItem(item, reciever);
					break;
				case "PoisonPotion":
					giver.GiveCharacterItem(item, reciever);
					break;
				default:
					// throw ex
					break;
			}
			return $"“{giver.Name} gave {reciever.Name} {item.Name}.";
		}

		public string GetStats()
		{
			throw new NotImplementedException();
		}

		public string Attack(string[] args)
		{
			Character attacker = charactersList.FirstOrDefault(c => c.Name == args[0]);
			Character reciever = charactersList.FirstOrDefault(c => c.Name == args[0]);
			if (!attacker.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (!reciever.IsAlive)
			{
				throw new ArgumentException(ErrorMessages.Dead);
			}
			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterDoesntExist, args[0]));
			}
			if (attacker.Type == reciever.Type)
				throw new ArgumentException(ErrorMessages.FriendlyFire);
			return $"{attacker.Name} attacks {reciever.Name} for {40} hit points! {reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!";
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}

		public string EndTurn(string[] args)
		{
			throw new NotImplementedException();
		}

		public bool IsGameOver()
		{
			throw new NotImplementedException();
		}

	}
}

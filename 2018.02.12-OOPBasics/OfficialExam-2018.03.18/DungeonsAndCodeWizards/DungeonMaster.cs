using DungeonsAndCodeWizards.Abstracts;
using DungeonsAndCodeWizards.Classes.Characters;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public class DungeonMaster
	{
		private List<Character> characters;
		private Stack<Item> itemsInPool;
		private CharacterFactory characterFactory;
		private ItemFactory itemFactory;
		private int lastSurvivorStandAloneRounds = 0;


		public DungeonMaster()
		{
			this.characters = new List<Character>();
			this.itemsInPool = new Stack<Item>();
			this.characterFactory = new CharacterFactory();
			this.itemFactory = new ItemFactory();
		}

		public string JoinParty(string[] args)
		{
			string faction = args[0];
			string type = args[1];
			string name = args[2];
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(ErrorMessages.InvalidName);
			}
			Character character = this.characterFactory.CreateCharacter(faction, type, name);
			this.characters.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = itemFactory.CreateItem(itemName);
			this.itemsInPool.Push(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = TryFindCharacter(characterName);
			CheckIsPoolEmpty();
			Item item = itemsInPool.First();
			character.ReceiveItem(item);
			itemsInPool.Pop();
			return $"{character.Name} picked up {item.Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = TryFindCharacter(characterName);
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return $"{character.Name} used {item.Name}.";
		}

		public string UseItemOn(string[] args)
		{
			string giverName = args[0];
			string receiverName = args[1];
			string itemName = args[2];
			Character giver = TryFindCharacter(giverName);
			Character receiver = TryFindCharacter(receiverName);
			Item item = giver.Bag.GetItem(itemName);
			giver.UseItemOn(item, receiver);
			return $"{giver.Name} used {item.Name} on {receiver.Name}.";
		}

		public string GiveCharacterItem(string[] args)
		{
			string giverName = args[0];
			string receiverName = args[1];
			string itemName = args[2];
			Character giver = TryFindCharacter(giverName);
			Character receiver = TryFindCharacter(receiverName);
			Item item = giver.Bag.GetItem(itemName);
			giver.GiveCharacterItem(item, receiver);
			return $"{giver.Name} gave {receiver.Name} {item.Name}.";
		}
		// dotuk raboti
		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var character in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
			{
				sb.AppendLine(character.ToString());
			}
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			Character attacker = TryFindCharacter(attackerName);
			Character receiver = TryFindCharacter(receiverName);
			if (!(attacker is IAttackable))
			{
				throw new ArgumentException(string.Format(ErrorMessages.CanNotAttack, attackerName));
			}
			((Warrior)attacker).Attack(receiver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
			if (!receiver.IsAlive)
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}
			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];
			Character healer = TryFindCharacter(healerName);
			Character receiver = TryFindCharacter(receiverName);
			if (!(healer is IHealable))
			{
				throw new ArgumentException(string.Format(ErrorMessages.CanNotHeal, healerName));
			}
			((Cleric)healer).Heal(receiver);
			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}

		public string EndTurn()
		{
			StringBuilder sb = new StringBuilder();
			int standAloneRounds = 0;
			foreach (var aliveCharacter in characters)
			{
				if (aliveCharacter.IsAlive)
				{
					double healthBeforeRest = aliveCharacter.Health;
					aliveCharacter.Rest();
					sb.AppendLine($"{aliveCharacter.Name} rests ({healthBeforeRest} => {aliveCharacter.Health})");
					standAloneRounds++;
				}
			}
			if (standAloneRounds <= 1)
			{
				this.lastSurvivorStandAloneRounds++;
			}
			else
			{
				this.lastSurvivorStandAloneRounds = 0;
			}
			return sb.ToString().TrimEnd();
		}

		public bool IsGameOver()
		{
			var aliveCharacters = characters.Count(c => c.IsAlive);
			bool oneOrZeroAlive = aliveCharacters <= 1;
			bool survivorSurvivedTooLong = this.lastSurvivorStandAloneRounds > 1;
			return oneOrZeroAlive && survivorSurvivedTooLong;
		}

		private void CheckIsPoolEmpty()
		{
			bool isPoolEmpty = !itemsInPool.Any();
			if (isPoolEmpty)
			{
				throw new InvalidOperationException(ErrorMessages.ItemsPoolEmpty);
			}
		}

		private Character TryFindCharacter(string characterName)
		{
			Character character = characters.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ErrorMessages.CharacterNotFound, characterName));
			}
			return character;
		}

	}
}

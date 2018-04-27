using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using DungeonsAndCodeWizards.Entities.Factories;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
		private List<Character> characters;
		private Stack<Item> items;

		private CharacterFactory characterFactory;
		private ItemFactory itemFactory;

		private int lastSurvivorRound;

		public DungeonMaster()
		{
			this.characters = new List<Character>();
			this.items = new Stack<Item>();

			this.characterFactory = new CharacterFactory();
			this.itemFactory = new ItemFactory();
		}

		public IReadOnlyCollection<Character> Characters => this.characters;

		public string JoinParty(string[] args)
		{
			string faction = args[0];
			string type = args[1];
			string name = args[2];

			Character character = this.characterFactory.CreateCharacter(faction, type, name);
			this.characters.Add(character);

			return string.Format(Consts.CharJoined, character.Name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = this.itemFactory.CreateItem(itemName);
			this.items.Push(item);
			return string.Format(Consts.ItemAdded, item.GetType().Name);
		}

		public string PickUpItem(string[] args)
		{
			string charName = args[0];
			Character character = this.FindCharacter(charName);

			Item item = this.items.Pop();
			character.Bag.AddItem(item);
			return string.Format(Consts.SuccessfulPickedUp, character.Name, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string charName = args[0];
			Character character = this.FindCharacter(charName);

			string itemName = args[1];
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(Consts.CharUsedItem, character.Name, itemName);
		}

		public string UseItemOn(string[] args)
		{
			string giverName = args[0];
			string recieverName = args[1];

			Character giver = this.FindCharacter(giverName);
			Character reciever = this.FindCharacter(recieverName);

			string itemName = args[2];
			Item item = giver.Bag.GetItem(itemName);
			reciever.UseItem(item);

			return string.Format(Consts.CharUsedItemOn, giver.Name, itemName, reciever.Name);
		}

		public string GiveCharacterItem(string[] args)
		{
			string giverName = args[0];
			string recieverName = args[1];

			Character giver = this.FindCharacter(giverName);
			Character reciever = this.FindCharacter(recieverName);

			string itemName = args[2];
			Item item = giver.Bag.GetItem(itemName);
			giver.GiveCharacterItem(item, reciever);

			return string.Format(Consts.CharGaveItem, giver.Name, reciever.Name, itemName);
		}

		public string GetStats()
		{
			StringBuilder builder = new StringBuilder();
			foreach (var character in this.characters.OrderByDescending(c=>c.IsAlive).ThenByDescending(c=>c.Health))
			{
				string lifeStatus = character.IsAlive ? "Alive" : "Dead";
				builder.AppendLine(string.Format(Consts.Stats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, lifeStatus));
			}
			return builder.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.FindCharacter(attackerName);
			Character receiver = this.FindCharacter(receiverName);

			if(attacker.GetType().Name == "Cleric")
			{
				throw new ArgumentException(string.Format(Consts.CanNotAttack, attackerName));
			}

			((Warrior)attacker).Attack(receiver);

			string output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

			if(!receiver.IsAlive)
			{
				output += Environment.NewLine + String.Format(Consts.DeadChar, receiver.Name);
			}
			return output;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string recieverName = args[1];

			Character healer = this.FindCharacter(healerName);
			Character receiver = this.FindCharacter(recieverName);

			if (healer.GetType().Name != "Cleric")
			{
				throw new ArgumentException(string.Format(Consts.CanNotHeal, healerName));
			}

			((IHealable)healer).Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}

		public string EndTurn(string[] args)
		{
			StringBuilder builder = new StringBuilder();
			int aliveCharactersCounter = 0;

			foreach (var character in this.characters.Where(c=>c.IsAlive==true))
			{
				double currentHealth = character.Health;
				character.Rest();
				double updatedHealth = character.Health;

				builder.AppendLine(string.Format(Consts.Rest, character.Name, currentHealth, updatedHealth));
				aliveCharactersCounter++;
			}
			if(aliveCharactersCounter<2)
			{
				this.lastSurvivorRound++;
			}
			return builder.ToString().Trim();
		}

		public bool IsGameOver()
		{
			if(this.lastSurvivorRound>1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private Character FindCharacter(string charName)
		{
			Character character = this.characters.FirstOrDefault(c => c.Name == charName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(Consts.CharNotFound, charName));
			}

			return character;
		}
	}
}

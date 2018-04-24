using System;
using System.Collections.Generic;
using System.Text;

public class GameController
{
	private IArmy army;
	private IWareHouse wareHouse;
	private MissionController missionController;
	private IWriter writer;

	private SoldierFactory soldiersFactory;
	private MissionFactory missionFactory;
	private AmmunitionFactory ammunitionFactory;

	public GameController(IWriter writer)
	{
		this.wareHouse = new WareHouse(writer);
		this.army = new Army(this.wareHouse);
		this.missionController = new MissionController(this.army, this.wareHouse);
		this.writer = writer;

		this.soldiersFactory = new SoldierFactory();
		this.missionFactory = new MissionFactory();
		this.ammunitionFactory = new AmmunitionFactory();
	}

	public void GiveInputToGameController(string input)
	{
		var data = input.Split();

		if (data[0].Equals("Soldier"))
		{
			if (data[1].Equals("Regenerate"))
			{
				string soldierType = data[2];

				this.army.RegenerateTeam(soldierType);
			}
			else
			{
				string type = data[1];
				string name = data[2];
				int age = int.Parse(data[3]);
				double experience = double.Parse(data[4]);
				double endurance = double.Parse(data[5]);

				ISoldier soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);
				this.army.AddSoldier(soldier);
			}
		}
		else if (data[0].Equals("WareHouse"))
		{
			string name = data[1];
			int number = int.Parse(data[2]);

			this.wareHouse.AddWeaponsToWarehouse(name, number);
		}
		else if (data[0].Equals("Mission"))
		{
			string missionType = data[1];
			int scoreToComplete = int.Parse(data[2]);

			IMission mission = this.missionFactory.CreateMission(missionType, scoreToComplete);
			string output = this.missionController.PerformMission(mission);
			this.writer.Append(output);
		}
	}

	public void ProduceSummary()
	{
		this.writer.Append(OutputMessages.Result);
		this.missionController.FailMissionsOnHold();

		this.writer.Append(string.Format(OutputMessages.MissionSuccessful, this.missionController.SuccessMissionCounter));
		this.writer.Append(string.Format(OutputMessages.MissionFailed, this.missionController.FailedMissionCounter));

		this.writer.Append(OutputMessages.Soldiers);

		foreach (var soldier in this.army.Soldiers)
		{
			this.writer.Append(soldier.ToString());
		}
		this.writer.PrintResult();
	}
}
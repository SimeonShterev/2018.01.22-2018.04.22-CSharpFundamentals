using NUnit.Framework;
using System.Reflection;
using System.Text;

public class MissionControllerTests
{
	[Test]
	public void TestMissionDeclined()
	{
		IWriter writer = new ConsoleWriter();
		IWareHouse wareHouse = new WareHouse(writer);
		IArmy army = new Army(wareHouse);
		MissionController missionController = new MissionController(army, wareHouse);

		MissionFactory missionFactory = new MissionFactory();
		IMission mission = missionFactory.CreateMission("Easy", 1);

		for (int counter = 0; counter < 4; counter++)
		{
			writer.Append(missionController.PerformMission(mission));
		}

		string expectedResult = "Mission declined";
		FieldInfo builderInfo = writer.GetType().GetField("builder", BindingFlags.Instance | BindingFlags.NonPublic);
		StringBuilder result = (StringBuilder)builderInfo.GetValue(writer);

		Assert.That(result.ToString().Contains(expectedResult), "Wrong output");
	}

	[Test]
	public void TestMissionCompleted()
	{
		IWriter writer = new ConsoleWriter();
		IWareHouse wareHouse = new WareHouse(writer);
		IArmy army = new Army(wareHouse);
		MissionController missionController = new MissionController(army, wareHouse);

		MissionFactory missionFactory = new MissionFactory();
		IMission mission = missionFactory.CreateMission("Easy", 0);
		writer.Append(missionController.PerformMission(mission));

		string expectedResult = "Mission completed";
		FieldInfo builderInfo = writer.GetType().GetField("builder", BindingFlags.Instance | BindingFlags.NonPublic);
		StringBuilder result = (StringBuilder)builderInfo.GetValue(writer);

		Assert.That(result.ToString().Contains(expectedResult), "Wrong output");
	}
}
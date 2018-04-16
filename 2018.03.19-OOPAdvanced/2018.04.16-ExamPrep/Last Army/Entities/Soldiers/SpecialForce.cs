using System.Collections.Generic;
using System.Text;

namespace Last_Army
{
    public class SpecialForce : Soldier
    {
        private const double OverallSkillMultiplier = 3.5;
		private const int Endurance_Increacement = 30;


		private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

        public SpecialForce(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
        {
			this.OverallSkill = (age + experience) * OverallSkillMultiplier;
        }

		protected override IReadOnlyList<string> WeaponsAllowed => throw new System.NotImplementedException();

		public override int EnduranceIncreacement => Endurance_Increacement;
	}
}
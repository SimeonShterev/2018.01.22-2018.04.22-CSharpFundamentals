using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private ICollection<IMissions> missionSet;

    public Commando(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
    {
        this.missionSet = new List<IMissions>();
    }

    public IReadOnlyCollection<IMissions> MissionsSet
    {
        get
        {
            return (IReadOnlyCollection<IMissions>)missionSet;
        }
    }

    public void AddMission(IMissions mission)
    {
        missionSet.Add(mission);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.CorpsType}{Environment.NewLine}Missions: ");
        foreach (var mission in missionSet)
        {
            sb.AppendLine($"  Code Name: {mission.CodeName} State: {mission.MissionState}");
        }
        string result = sb.ToString().TrimEnd();
        return result;
    }
}
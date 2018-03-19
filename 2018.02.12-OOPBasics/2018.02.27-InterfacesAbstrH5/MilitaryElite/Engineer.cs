using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepair> repairSet;

    public Engineer(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.repairSet = new List<IRepair>();
    }

    public IReadOnlyCollection<IRepair> RepairSet
    {
        get
        {
            return (IReadOnlyCollection<IRepair>)repairSet;
        }
    }

    public void AddRepair(Repair repair)
    {
        this.repairSet.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.CorpsType}")
            .AppendLine("Repairs:");
        foreach (var repair in repairSet)
        {
            sb.AppendLine($"  {repair.ToString()}");
        }
        string result = sb.ToString().TrimEnd();
        return result;
    }
}
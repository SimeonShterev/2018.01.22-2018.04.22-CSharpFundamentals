using System;
using System.Collections.Generic;
using System.Text;

public interface IEngineer
{
    IReadOnlyCollection<IRepair> RepairSet { get; }

    void AddRepair(Repair repair);
}
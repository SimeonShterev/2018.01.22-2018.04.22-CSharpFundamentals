using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando
{
    IReadOnlyCollection<IMissions> MissionsSet { get; }

    void AddMission(IMissions mission);
}
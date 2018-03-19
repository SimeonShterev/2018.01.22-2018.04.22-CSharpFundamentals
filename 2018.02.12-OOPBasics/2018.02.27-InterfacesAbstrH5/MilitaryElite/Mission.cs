using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMissions
{
    private MissionState missionState;

    public Mission(string codeName, string mission)
    {
        this.CodeName = codeName;
        CompleteMission(mission);
    }

    public string CodeName { get; private set; }

    public MissionState MissionState => this.missionState;

    //public MissionState MissionStateToRead => this.missionState;

    public void CompleteMission(string mission)
    {
        bool isValidState = Enum.TryParse(typeof(MissionState), mission, out object outState);
        if(!isValidState)
        {
            throw new ArgumentException("Invalid Mission State");
        }
        this.missionState = (MissionState)outState;
    }
}
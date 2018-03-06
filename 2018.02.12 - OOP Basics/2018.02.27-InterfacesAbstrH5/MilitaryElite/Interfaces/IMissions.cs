using System;
using System.Collections.Generic;
using System.Text;

    public interface IMissions
    {
        string CodeName { get; }

        MissionState MissionState { get; }

        void CompleteMission(string misssion);
    }
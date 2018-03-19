using System;
using System.Collections.Generic;
using System.Text;

public class MyPrivateList
{
    private List<Citizen> privateList;

    public MyPrivateList()
    {
        privateList = new List<Citizen>();
    }

    public void AddCitizensToList(Citizen citizen)
    {
        privateList.Add(citizen);
    }

    public IReadOnlyCollection<Citizen> ReadList
    {
        get
        {
            return privateList;
        }
    }
}
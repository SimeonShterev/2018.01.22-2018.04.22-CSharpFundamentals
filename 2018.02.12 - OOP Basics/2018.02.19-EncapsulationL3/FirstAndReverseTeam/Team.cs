using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reverseTeam;

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reverseTeam = new List<Person>();
        this.name = name;
    }
    public List<Person> FirstTeam
    {
        get
        {
            return this.firstTeam;
        }
    }
    public List<Person> ReverseTeam
    {
        get
        {
            return this.reverseTeam;
        }
    }
    public void AddPlayer(Person person)
    {
        if(person.Age<40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reverseTeam.Add(person);
        }
    }
}

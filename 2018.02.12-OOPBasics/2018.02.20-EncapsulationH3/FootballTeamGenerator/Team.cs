using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Player> playersList;

    public Team(string name)
    {
        this.Name = name;
        this.playersList = new List<Player>();
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public int PlayersCount
    {
        get { return this.playersList.Count; }
    }

    public void AddPlayer(Player player)
    {
        this.playersList.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player player = playersList.Find(p => p.Name == playerName);
        if(!playersList.Contains(player))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
        }
        else
        {
            this.playersList.Remove(player);
        }
    }

    public int CalculateRate(Team team)
    {
        double rate = 0.0;
        foreach (var player in this.playersList)
        {
            rate += player.GetStats;
        }
        rate = rate / this.playersList.Count;
        rate = Math.Round(rate, 0);
        return (int)rate;
    }
}

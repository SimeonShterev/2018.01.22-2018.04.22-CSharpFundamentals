using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : IBreaks, IAccelerate
{
    private const string car = "488-Spider";

    private string personName;

    public Ferrari(string personName)
    {
        this.personName = personName;
    }

    public string PrintBreaks()
    {
        return "Brakes!";
    }

    public string PrintGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(car)
            .Append($"/{PrintBreaks()}/")
            .Append($"{PrintGas()}/")
            .Append(this.personName);
        return sb.ToString();
    }
}
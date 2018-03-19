using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
    private string type;

    public Cargo(string type)
    {
        this.type = type;
    }

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }
}

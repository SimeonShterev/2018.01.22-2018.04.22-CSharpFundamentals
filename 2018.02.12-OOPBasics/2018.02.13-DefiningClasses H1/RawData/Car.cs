using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private Cargo cargo;
    private List<Tire> allTires;
    private string model;
    private Engine engine;

    public Car(Cargo cargo, List<Tire> allTires, string model, Engine engine)
    {
        this.cargo = cargo;
        this.allTires = allTires;
        this.model = model;
       // this.engine = engine;
    }

    public int TiresCount
    {
        get { return this.allTires.Count; }
    }

    public string Model
    {
        get { return this.model; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
    }

    public Engine Engine
    {
        get { return this.engine; }
    }
}

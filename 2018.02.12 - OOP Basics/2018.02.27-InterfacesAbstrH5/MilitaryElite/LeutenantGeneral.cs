using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantSoldier
{
    private ICollection<ISolder> privateSet;

    public LeutenantGeneral(int id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName, salary)
    {
        this.privateSet = new List<ISolder>();
    }

    public IReadOnlyCollection<ISolder> PrivatesSet { get; private set; }

    public void AddPrivate(ISolder @private)
    {
        privateSet.Add(@private);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine("Privates:");
        foreach (var @private in privateSet)
        {
            sb.AppendLine($"  {@private.ToString()}");
        }
        string result = sb.ToString().TrimEnd();
        return result;
    }
}
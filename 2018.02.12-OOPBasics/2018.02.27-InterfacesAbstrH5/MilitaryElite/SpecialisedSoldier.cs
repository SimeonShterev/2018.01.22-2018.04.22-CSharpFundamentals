using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private Corps corpsType;

    public SpecialisedSoldier(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
    }

    public Corps corps { get; set; }

    public Corps CorpsType => this.corpsType;

    public void DefineCorpsType(string corps)
    {
        bool isValid = Enum.TryParse(typeof(Corps), corps, out object outSpecSoldier);
        if (!isValid)
        {
            throw new ArgumentException("Invalid corps");
        }
        this.corpsType = (Corps)outSpecSoldier;
    }
}
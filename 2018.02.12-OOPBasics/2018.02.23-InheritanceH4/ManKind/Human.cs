using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private const string NAME_LENGHT_EXCEPTION = "Expected length at least {0} symbols! Argument: {1}";
    private const string NAME_CASE_EXCEPTION = "Expected upper case letter! Argument: {0}";
    private const int minFirstNameLenght = 4;
    private const int minLastNameLenght = 3;
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            CheckFirstLetterCase(value, minLastNameLenght, nameof(lastName));
            this.lastName = value;
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            CheckFirstLetterCase(value, minFirstNameLenght, nameof(firstName));
            this.firstName = value;
        }
    }


    private void CheckFirstLetterCase(string value, int minLenght, string type)
    {
        if (char.IsLower(value[0]))
        {
            throw new ArgumentException(string.Format(NAME_CASE_EXCEPTION, type));
        }
        if (value.Length < minLenght)
        {
            throw new ArgumentException(string.Format(NAME_LENGHT_EXCEPTION, minLenght, type));
        }
    }
}
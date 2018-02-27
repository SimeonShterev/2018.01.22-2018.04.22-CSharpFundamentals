using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const string FACULTY_NUMBER_EXCEPTION = "Invalid faculty number!";
    private const string pattern = @"^[0-9a-zA-Z]{5,10}$";
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (Regex.IsMatch(value, pattern))
            {
                this.facultyNumber = value;
            }
            else
            {
                throw new ArgumentException(FACULTY_NUMBER_EXCEPTION);
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Faculty number: {this.FacultyNumber}");
        return sb.ToString();
    }
}
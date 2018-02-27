using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if(value.Length<3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }
    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if(value<1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }
    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if(value<460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:f2} leva.";
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (this.age < 30)
        {
            this.salary += this.salary * bonus / 200;
        }
        else
        {
            this.salary += this.salary * bonus / 100;
        }
    }
}

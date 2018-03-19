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
    }
    public int Age
    {
        get { return this.age; }
    }
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }
    //public override string ToString()
    //{
    //    return $"{firstName} {lastName} receives {salary:f2} leva.";
    //}

    //public void IncreaseSalary(decimal bonus)
    //{
    //    if (this.age < 30)
    //    {
    //        this.salary += this.salary * bonus / 200;
    //    }
    //    else
    //    {
    //        this.salary += this.salary * bonus / 100;
    //    }
    //}
}

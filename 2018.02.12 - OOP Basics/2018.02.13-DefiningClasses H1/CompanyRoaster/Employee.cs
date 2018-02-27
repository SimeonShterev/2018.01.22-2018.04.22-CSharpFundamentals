using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    private string name;
    private double salary;
    private string position;
    private string email = "n/a";
    private int age = -1;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Email
    {
        get { return email; }
        set { email = value; }
    }


    public string Position
    {
        get { return position; }
        set { position = value; }
    }


    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Employee(string name, double salary, string position, string email = "asd", int age = 12)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.email = email;
        this.age = age;
    }
}

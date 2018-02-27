using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Department
{
    private List<Employee> emploees;
    private string name;

    public Department(string name)
    {
        this.emploees = new List<Employee>();
        this.name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public double AverageSalary()
    {
        return this.emploees.Select(e => e.Salary).Average();
    }

    public void AddEmployee(Employee employee)
    {
        this.emploees.Add(employee);
    }
}
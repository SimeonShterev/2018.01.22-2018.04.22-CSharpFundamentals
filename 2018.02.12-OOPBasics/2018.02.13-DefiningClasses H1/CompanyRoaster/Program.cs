using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Department> departmentList = new List<Department>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] dataForPerson = Console.ReadLine().Split();
            string name = dataForPerson[0];
            double salary = double.Parse(dataForPerson[1]);
            string position = dataForPerson[2];
            string depName = dataForPerson[3];
            int age = -1;
            string email = "n/a";

            if (dataForPerson.Length == 5)
            {
                if (!int.TryParse(dataForPerson[4], out age))
                {
                    email = dataForPerson[4];
                }
            }
            else if (dataForPerson.Length == 6)
            {
                email = dataForPerson[4];
                age = int.Parse(dataForPerson[5]);
            }
            Employee employee = new Employee(name, salary, position, email, age);
            if(!departmentList.Any(d=>d.Name==depName))
            {
                Department department = new Department(name);
                departmentList.Add(department);
            }
        }
        var highestAvDep = departmentList.OrderByDescending(d => d.AverageSalary()).First();
        Console.WriteLine($"Highest Average Salary: {highestAvDep.Name}");
        int debug = 0;
    }
}

using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
			Employee employee = new Employee("GoshoEmploito");
			List<string> peshosDocs = new List<string>() { "doc1", "doc2" };
			Employee manager = new Manager("PeshoManagera", peshosDocs);
			Employee justWorker = new JustWorker("Manol4o", 40);
			List<Employee> employeeList = new List<Employee>();
			employeeList.Add(employee);
			employeeList.Add(manager);
			employeeList.Add(justWorker);

			DetailsPrinter detail = new DetailsPrinter(employeeList);
			detail.PrintDetails();
        }
    }
}

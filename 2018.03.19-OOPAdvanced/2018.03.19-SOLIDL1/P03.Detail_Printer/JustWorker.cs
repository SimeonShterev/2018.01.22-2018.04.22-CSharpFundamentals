using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
	public class JustWorker : Employee
	{
		public JustWorker(string name, int hoursWorked) 
			: base(name)
		{
			this.HoursWorked = hoursWorked;
		}

		public int HoursWorked { get; set; }

		public override void PrintEmployee(Employee employee)
		{
			base.PrintEmployee(employee);
			Console.WriteLine(((JustWorker)employee).HoursWorked);
		}
	}
}

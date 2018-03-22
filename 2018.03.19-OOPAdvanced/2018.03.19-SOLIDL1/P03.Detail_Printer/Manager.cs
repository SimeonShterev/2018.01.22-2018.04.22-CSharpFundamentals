using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

		public override void PrintEmployee(Employee manager)
		{
			base.PrintEmployee(manager);
			Console.WriteLine(string.Join(Environment.NewLine, ((Manager)manager).Documents));
		}
	}
}

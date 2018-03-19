using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Family family = new Family();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] lineData = Console.ReadLine().Split();
            int age = int.Parse(lineData[1]);
            string name = lineData[0];
            var person = new Person(age, name);
            if (age > 30)
            {
                family.AddMembers(person);
            }
        }
        family.PrintEverybody();
    }
}

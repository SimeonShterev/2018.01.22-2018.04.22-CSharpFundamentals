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
            string[] linesData = Console.ReadLine().Split();
            string name = linesData[0];
            int age = int.Parse(linesData[1]);
            var member = new Person(age, name);
            family.AddMembers(member);
        }
        Person oldest = family.OldestFamilyMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}

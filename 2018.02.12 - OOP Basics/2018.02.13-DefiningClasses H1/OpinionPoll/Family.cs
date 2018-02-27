using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Family
{
    List<Person> listOfPeople = new List<Person>();

    public void AddMembers(Person member)
    {
        this.listOfPeople.Add(member);
    }

    Person oldestPerson = new Person();
    public Person OldestFamilyMember()
    {
        return listOfPeople.OrderByDescending(p => p.Age).FirstOrDefault();
    }

    public void PrintEverybody()
    {
        foreach (var person in listOfPeople.OrderBy(p=>p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
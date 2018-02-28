using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        string input;
        while ((input = Console.ReadLine())!="End")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            string id = tokens[tokens.Length - 1];
            if(tokens.Length==3)
            {
                //people
                int age = int.Parse(tokens[1]);
                Person person = new Person(id, name, age);
                list.Add(person.Id);
            }
            else
            {
                //robots
                Robot robot = new Robot(id, name);
                list.Add(robot.Id);
            }
        }
        string idEnd = Console.ReadLine();
        foreach (var item in list)
        {
            if(item.EndsWith(idEnd))
                Console.WriteLine(item);
        }
    }
}
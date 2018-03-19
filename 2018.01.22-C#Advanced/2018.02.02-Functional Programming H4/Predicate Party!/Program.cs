using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = command.Split();
                List<string> temp = new List<string>();
                if (commandArgs[0] == "Remove")
                {
                    temp = CreateTemporaryList(people, commandArgs, temp);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if(people.Contains(temp[i]))
                        {
                            people.Remove(temp[i]);
                        }
                    }
                }
                else
                {
                    temp = CreateTemporaryList(people, commandArgs, temp);
                    people.AddRange(temp);
                }
            }
            people.Sort();
            if (people.Any())
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> CreateTemporaryList(List<string> people, string[] commandArgs, List<string> temp)
        {
            Func<List<string>, string, List<string>> startsWith = (list, token) => list.Where(x => x.StartsWith(token)).ToList();
            Func<List<string>, string, List<string>> endsWith = (list, token) => list.Where(x => x.EndsWith(token)).ToList();
            Func<List<string>, int, List<string>> length = (list, token) => list.Where(x => x.Length == token).ToList();
            switch (commandArgs[1])
            {
                case "StartsWith":
                    temp = startsWith(people, commandArgs[2]);
                    break;
                case "EndsWith":
                    temp = endsWith(people, commandArgs[2]);
                    break;
                case "Length":
                    int nameLength = int.Parse(commandArgs[2]);
                    temp = length(people, nameLength);
                    break;
            }
            return temp;
        }
    }
}

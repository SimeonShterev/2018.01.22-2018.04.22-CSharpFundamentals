using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string command;
            List<string> bannedPeople = new List<string>();
            Queue<string> addFilters = new Queue<string>();
            string removeFilters = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command.Split(new char[] { ';' });
                if (commandArgs[0] == "Add filter")
                {
                    addFilters.Enqueue(commandArgs[1] + ";" + commandArgs[2]);
                }
                else
                {
                    removeFilters = commandArgs[1] + ";" + commandArgs[2];
                }
                if (addFilters.Contains(removeFilters))
                {
                    for (int i = 0; i < addFilters.Count; i++)
                    {
                        if (addFilters.Peek() == removeFilters)
                            addFilters.Dequeue();
                        else
                            addFilters.Enqueue(addFilters.Dequeue());
                    }
                }
            }
            int count = addFilters.Count;
            for (int i = 0; i < count; i++)
            {
                string[] commandArgs = addFilters.Dequeue().Split(new char[] { ';' });
                List<string> temp = new List<string>();
                bannedPeople.AddRange(CreateTemporaryList(people, commandArgs, bannedPeople));
            }
            for (int i = 0; i < bannedPeople.Count; i++)
            {
                if (people.Contains(bannedPeople[i]))
                {
                    people.Remove(bannedPeople[i]);
                }
            }
            Console.WriteLine(string.Join(" ", people));
        }

        private static List<string> CreateTemporaryList(List<string> people, string[] commandArgs, List<string> temp)
        {
            Func<List<string>, string, List<string>> startsWith = (list, token) => list.Where(x => x.StartsWith(token)).ToList();
            Func<List<string>, string, List<string>> endsWith = (list, token) => list.Where(x => x.EndsWith(token)).ToList();
            Func<List<string>, int, List<string>> length = (list, token) => list.Where(x => x.Length == token).ToList();
            Func<List<string>, string, List<string>> contains = (list, token) => list.Where(x => x.Contains(token)).ToList();
            switch (commandArgs[0])
            {
                case "Starts with":
                    temp = startsWith(people, commandArgs[1]);
                    break;
                case "Ends with":
                    temp = endsWith(people, commandArgs[1]);
                    break;
                case "Length":
                    int nameLength = int.Parse(commandArgs[1]);
                    temp = length(people, nameLength);
                    break;
                case "Contains":
                    temp = contains(people, commandArgs[1]);
                    break;
            }
            return temp;
        }
    }
}

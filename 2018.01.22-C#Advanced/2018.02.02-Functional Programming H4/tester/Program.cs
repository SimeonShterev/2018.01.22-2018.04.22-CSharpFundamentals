using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string command;
            Queue<string> addFilters = new Queue<string>();
            string removeFilters = string.Empty;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = command.Split(new char[] { ';' });
                if(commandArgs[0]=="Add filter")
                {
                    addFilters.Enqueue(commandArgs[1] + ";" + commandArgs[2]);
                }
                else
                {
                    removeFilters = commandArgs[1] + ";" + commandArgs[2];
                }
                if(addFilters.Contains(removeFilters))
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
            int debug = 0;
        }
    }
}

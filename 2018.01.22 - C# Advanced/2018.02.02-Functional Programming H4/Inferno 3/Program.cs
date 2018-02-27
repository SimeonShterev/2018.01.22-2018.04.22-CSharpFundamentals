using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inferno_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            Dictionary<string, List<int>> filters = new Dictionary<string, List<int>>();
            string command;
            while ((command = Console.ReadLine()) != "Forge")
            {
                AllCommands(filters, command, gems);
            }
            foreach (var pair in filters)
            {
                foreach (var nums in pair.Value)
                {
                    gems.Remove(nums);
                }
            }
            Console.WriteLine(string.Join(" ", gems));
        }

        private static void AllCommands(Dictionary<string, List<int>> filters, string command, List<int> gems)
        {
            string[] commandArgs = command.Split(new char[] { ';' });
            string filterType = commandArgs[1];
            int parameter = int.Parse(commandArgs[2]);
            string dictKey = filterType + " " + parameter;
            if (commandArgs[0] == "Exclude")
            {
                filters[dictKey] = MakeValue(gems, filterType, parameter);
            }
            else
            {
                filters.Remove(dictKey);
            }
        }

        private static List<int> MakeValue(List<int> gems, string filterType, int parameter)
        {
            List<int> dictValue = new List<int>();
            switch (filterType)
            {
                case "Sum Left":
                    return dictValue = gems.Where(num =>
                    {
                        int index = gems.IndexOf(num);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        return leftGem + num == parameter;
                    }).ToList();
                case "Sum Right":
                    return dictValue = gems.Where(num =>
                    {
                        int index = gems.IndexOf(num);
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return rightGem + num == parameter;
                    }).ToList();
                case "Sum Left Right":
                    return dictValue = gems.Where(num =>
                    {
                        int index = gems.IndexOf(num);
                        int leftGem = index > 0 ? gems[index - 1] : 0;
                        int rightGem = index < gems.Count - 1 ? gems[index + 1] : 0;
                        return leftGem + num + rightGem == parameter;
                    }).ToList();
                default:
                    throw new ArgumentException();
            }
        }
    }
}

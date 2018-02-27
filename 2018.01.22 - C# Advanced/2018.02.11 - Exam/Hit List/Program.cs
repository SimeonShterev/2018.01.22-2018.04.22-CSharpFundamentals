using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();
            string command;
            while ((command = Console.ReadLine()) != "end transmissions")
            {
                string[] nameAndDetails = command.Split(new char[] { '=' }).ToArray();
                string name = nameAndDetails[0];
                string[] details = nameAndDetails[1].Split(new char[] { ';' });
                if (!data.ContainsKey(name))
                {
                    data.Add(name, new Dictionary<string, string>());
                    fillDictionary(data, name, details);
                }
                else
                {
                    fillDictionary(data, name, details);
                }
            }
            string[] killInfo = Console.ReadLine().Split();
            string personToKill = killInfo[1];
            Console.WriteLine($"Info on {personToKill}:");
            int infoIndex = 0;
            foreach (var pair in data[personToKill].OrderBy(x=>x.Key))
            {
                string key = pair.Key;
                string value = pair.Value;
                Console.WriteLine($"---{key}: {value}");
                infoIndex = infoIndex + key.Length + value.Length;
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if(infoIndex>=targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int needMore = targetIndex - infoIndex;
                Console.WriteLine($"Need {needMore} more info.");
            }
        }

        private static void fillDictionary(Dictionary<string, Dictionary<string, string>> data, string name, string[] details)
        {
            foreach (var outerValues in details)
            {
                string[] innerKeyValuePair = outerValues.Split(new char[] { ':' });
                string innerKey = innerKeyValuePair[0];
                string innerValue = innerKeyValuePair[1];
                data[name][innerKey] = innerValue;
            }
        }
    }
}

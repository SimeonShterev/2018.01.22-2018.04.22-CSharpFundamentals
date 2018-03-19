using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = input[0];
            int last = input[1];
            string criteria = Console.ReadLine();
            List<int> list = new List<int>();
            for (int i = first; i <= last; i++)
            {
                list.Add(i);
            }
            Func<List<int>, string, List<int>> condition = (x, crop) => crop == "odd" ? x.Where(y => y % 2 != 0).ToList() : x.Where(y => y % 2 == 0).ToList();
            List<int> putkiMaini = condition(list, criteria);
            Console.WriteLine(string.Join(" ", putkiMaini));
        }
    }
}

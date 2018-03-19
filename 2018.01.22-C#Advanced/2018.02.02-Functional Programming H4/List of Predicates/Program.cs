using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int last = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> nums = new List<int>();
            Func<int, int, bool> condition = (x, div) => x % div == 0 ? true : false;
            for (int i = 1; i <= last; i++)
            {
                int counter = 0;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (condition(i, dividers[j]))
                    {
                        counter++;
                    }
                }
                if (counter == dividers.Length)
                {
                    nums.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

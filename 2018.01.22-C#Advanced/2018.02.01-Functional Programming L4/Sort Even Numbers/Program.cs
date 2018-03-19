using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new string[] { ", " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i))
                .Where(num => num % 2 == 0)
                .OrderBy(num=>num)
                .ToArray();
            Console.WriteLine(string.Join(", ", input));
        }
    }
}

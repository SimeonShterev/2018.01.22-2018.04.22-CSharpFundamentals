using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> checker = (x, y) => x % y == 0;
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());
            for (int i = 0; i < input.Count; i++)
            {
                if(checker(input[i], divisor))
                {
                    input.Remove(input[i]);
                    i--;
                }
            }
            input.Reverse();
            Console.WriteLine(string.Join(" ", input));
        }
    }
}

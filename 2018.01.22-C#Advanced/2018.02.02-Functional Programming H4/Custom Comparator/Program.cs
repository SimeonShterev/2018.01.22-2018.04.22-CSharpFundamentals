using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int[]> evenNumMaker = arr => arr.Where(x => x % 2 == 0).ToArray(); 
            Func<int[], int[]> oddNumMaker = arr => arr.Where(x => x % 2 != 0).ToArray();
            int[] evenNums = evenNumMaker(array);
            Array.Sort(evenNums);
            int[] oddNums = oddNumMaker(array);
            Array.Sort(oddNums);
            Console.WriteLine(string.Join(" ", evenNums) + " " + string.Join(" ", oddNums));
        }
    }
}

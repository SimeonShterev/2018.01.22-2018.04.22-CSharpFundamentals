using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Min_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> findSmallest = arr => arr.Min();
            int result = findSmallest(array);
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int dec = int.Parse(Console.ReadLine());
            if(dec==0)
            {
                Console.WriteLine(0);
                return;
            }
            Stack<int> binStack = new Stack<int>();
            while(dec!=0)
            {
                binStack.Push(dec % 2);
                dec /= 2;
            }
            while(binStack.Count!=0)
            {
                Console.Write(binStack.Pop());
            }
            Console.WriteLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            Predicate<char[]> pred = ch => ch.Sum(c => c) >= N ? true : false;
            for (int i = 0; i < input.Length; i++)
            {
                char[] ch = input[i].ToCharArray();
                if(pred(ch))
                {
                    Console.WriteLine(input[i]);
                    break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Predicate<string> condition = str => str.Length <= length;
            for (int i = 0; i < names.Length; i++)
            {
                if(condition(names[i]))
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}

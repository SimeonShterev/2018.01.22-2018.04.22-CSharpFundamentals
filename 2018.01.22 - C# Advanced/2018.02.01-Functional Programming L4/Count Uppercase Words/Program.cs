using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> condition = word => word[0] == word.ToUpper()[0];
            string[] input = Console.ReadLine()
                .Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Where(w => condition(w))
                .ToArray();
            Console.WriteLine(string.Join("\r\n", input));
        }
    }
}

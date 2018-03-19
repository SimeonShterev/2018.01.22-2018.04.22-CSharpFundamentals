using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int> { 1, 2, 3, 4, 5 };
            var query = test.Where(x => x % 2 == 0);
            test.Add(8);
            test.Add(88);
            test.Add(12);
            foreach (var num in query)
            {
                Console.WriteLine(num + " ");
            }

            List<string> mest = new List<string> {"cat", "dog"};
            var asd = mest.Select(x=>x.ToUpper());
            test.Add(8);
            test.Add(88);
            test.Add(12);
            foreach (var num in asd)
            {
                Console.WriteLine(num + " ");
            }
        }
    }
}

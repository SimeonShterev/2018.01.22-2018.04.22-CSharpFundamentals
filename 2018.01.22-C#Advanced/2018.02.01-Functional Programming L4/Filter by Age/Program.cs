using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = int.Parse;
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, int> data = new Dictionary<string, int>(N);
            for (int i = 0; i < N; i++)
            {
                string[] nameAge = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                data.Add(nameAge[0], parser(nameAge[1]));
            }
        }
    }
}

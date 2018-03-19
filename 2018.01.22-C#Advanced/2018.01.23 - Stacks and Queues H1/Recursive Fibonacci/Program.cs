using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            long currentFib = 0;
            Dictionary<int, long> numbersFib = new Dictionary<int, long>();
            for (int i = 1; i<=N; i++)
            {
                currentFib = GetFibonacci(i, numbersFib);
                if (!numbersFib.ContainsKey(i))
                {
                    numbersFib[i] = currentFib;
                }
            }
            Console.WriteLine(currentFib);
        }

        private static long GetFibonacci(int N, Dictionary<int,long> numbersFib)
        {
            if(N==1 || N == 2)
            {
                return 1;
            }
            if(numbersFib.ContainsKey(N))
            {
                return numbersFib[N];
            }
            return GetFibonacci(N - 1, numbersFib) + GetFibonacci(N - 2, numbersFib);
        }
    }
}

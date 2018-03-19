using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int R = input[0];
            int C = input[1];
            int[][] matrix = new int[R][];
            int filler = 0;
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    filler++;
                    matrix[rows][cols] = filler;
                }
            }

        }
    }
}

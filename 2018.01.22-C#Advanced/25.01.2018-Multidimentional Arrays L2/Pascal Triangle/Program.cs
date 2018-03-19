using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int[][] pascalTr = new int[height][];
            for (int rows = 0; rows < height; rows++)
            {
                pascalTr[rows] = new int[rows + 1];
                for (int cols = 0; cols <= rows; cols++)
                {
                    if (cols == 0 || cols == rows)
                    {
                        pascalTr[rows][cols] = 1;
                    }
                    else
                    {
                        pascalTr[rows][cols] = pascalTr[rows - 1][cols - 1] + pascalTr[rows - 1][cols];
                    }
                }
            }
            foreach (var row in pascalTr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int R = int.Parse(Console.ReadLine());
            int[][] firstJagged = new int[R][];
            int[][] secondJagged = new int[R][];
            int elementsFirst = 0;
            int elementsSecond = 0;
            for (int rows = 0; rows < R; rows++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                firstJagged[rows] = new int[input.Length];
                for (int cols = 0; cols < input.Length; cols++)
                {
                    firstJagged[rows][cols] = input[cols];
                    elementsFirst++;
                }
            }
            for (int rows = 0; rows < R; rows++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                secondJagged[rows] = new int[input.Length];
                for (int cols = 0; cols < input.Length; cols++)
                {
                    secondJagged[rows][cols] = input[cols];
                    elementsSecond++;
                }
            }
            int colsCommon = 0;
            for (int i = 0; i < R; i++)
            {
                int firstCols = firstJagged[i].Length;
                int secondCols = secondJagged[i].Length;
                if(i==0)
                {
                    colsCommon = firstCols + secondCols;
                }
                if(firstCols+secondCols!=colsCommon)
                {
                    Console.WriteLine($"The total number of cells is: {elementsFirst+elementsSecond}");
                    Environment.Exit(0);
                }
            }
            int[][] rectMatrix = new int[R][];
            for (int rows = 0; rows < R; rows++)
            {
                rectMatrix[rows] = new int[colsCommon];
                for (int cols = 0; cols < firstJagged[rows].Length; cols++)
                {
                    rectMatrix[rows][cols] = firstJagged[rows][cols];
                }
            }
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < secondJagged[rows].Length; cols++)
                {
                    int column = rectMatrix[rows].Length - 1 - cols;
                    rectMatrix[rows][column] = secondJagged[rows][cols];
                }
            }
            foreach (var row in rectMatrix)
            {
                Console.WriteLine("[" + string.Join(", ", row) + "]");
            }
        }
    }
}

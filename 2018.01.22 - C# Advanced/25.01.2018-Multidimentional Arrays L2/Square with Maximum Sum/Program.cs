using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[rowsAndCols[0]][];
            int maxSum = int.MinValue;
            int biggestNumRow = 0;
            int biggestNumCol = 0;
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                int[] inputRows = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[rows] = inputRows;
            }
            for (int rows = 0; rows < matrix.Length - 1; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length - 1; cols++)
                {
                    int currentSum = matrix[rows][cols] + matrix[rows + 1][cols] + matrix[rows + 1][cols + 1] + matrix[rows][cols + 1];
                    if(maxSum<currentSum)
                    {
                        maxSum = currentSum;
                        biggestNumCol = cols;
                        biggestNumRow = rows;
                    }
                }
            }
            int num11 = matrix[biggestNumRow][biggestNumCol];
            int num12 = matrix[biggestNumRow][biggestNumCol +1];
            int num21 = matrix[biggestNumRow +1][biggestNumCol];
            int num22 = matrix[biggestNumRow + 1][biggestNumCol + 1];
            Console.WriteLine($"{num11} {num12}\r\n{num21} {num22}");
            Console.WriteLine(maxSum);
        }
    }
}

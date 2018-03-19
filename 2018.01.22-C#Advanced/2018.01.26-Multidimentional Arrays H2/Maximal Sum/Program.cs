using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int R = input[0];
            int C = input[1];
            int[][] matrix = new int[R][];
            for (int rows = 0; rows < R; rows++)
            {
                int[] rowInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[rows] = rowInput;
            }
            int maxSum = int.MinValue;
            int indexRow = 0;
            int indexCol = 0;
            for (int rows = 0; rows < R-2; rows++)
            {
                for (int cols = 0; cols < C - 2; cols++)
                {
                    int currentSum = matrix[rows][cols] + matrix[rows][cols + 1] + matrix[rows][cols + 2] + matrix[rows + 1][cols] + matrix[rows + 1][cols + 1] + matrix[rows + 1][cols + 2] + matrix[rows+2][cols] + matrix[rows+2][cols + 1] + matrix[rows+2][cols + 2];
                    if(maxSum<currentSum)
                    {
                        maxSum = currentSum;
                        indexRow = rows;
                        indexCol = cols;
                    }
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    Console.Write($"{matrix[indexRow + rows][indexCol + cols]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

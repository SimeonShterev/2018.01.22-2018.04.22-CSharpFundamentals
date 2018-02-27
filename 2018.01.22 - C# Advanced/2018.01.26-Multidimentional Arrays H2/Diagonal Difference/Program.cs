using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[][] matrix = new int[N][];
            for (int rows = 0; rows < N; rows++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[rows] = inputRow;
            }
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            for (int rows = 0; rows < N; rows++)
            {
                for (int cols = 0; cols < N; cols++)
                {
                    if(rows==cols)
                    {
                        firstDiagonalSum += matrix[rows][cols];
                    }
                    if(rows+cols==N-1)
                    {
                        secondDiagonalSum += matrix[rows][cols];
                    }
                }
            }
            int absDiff = Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(absDiff);
        }
    }
}

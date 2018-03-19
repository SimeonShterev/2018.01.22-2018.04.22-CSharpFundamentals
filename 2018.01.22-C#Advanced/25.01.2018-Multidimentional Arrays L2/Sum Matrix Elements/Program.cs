using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[rowsAndCols[0]][];
            int sum = 0;
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                int[] inputRows = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach(int num in inputRows)
                {
                    sum += num;
                }
                matrix[rows] = inputRows;
            }
            Console.WriteLine(rowsAndCols[0]);
            Console.WriteLine(rowsAndCols[1]);
            Console.WriteLine(sum);
        }
    }
}

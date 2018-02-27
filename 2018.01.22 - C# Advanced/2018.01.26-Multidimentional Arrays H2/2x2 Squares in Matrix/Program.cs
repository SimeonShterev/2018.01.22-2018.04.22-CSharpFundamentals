using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int R = input[0];
            int C = input[1];
            string[][] matrix = new string[R][];
            for (int rows = 0; rows < R; rows++)
            {
                string[] inputRow = Console.ReadLine().Split().ToArray();
                matrix[rows] = inputRow;
            }
            int counter = 0;
            for (int rows = 0; rows < R-1; rows++)
            {
                for (int cols = 0; cols < C-1; cols++)
                {
                    if(matrix[rows][cols]==matrix[rows+1][cols] && matrix[rows][cols] == matrix[rows + 1][cols+1] && matrix[rows][cols] == matrix[rows][cols+1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}

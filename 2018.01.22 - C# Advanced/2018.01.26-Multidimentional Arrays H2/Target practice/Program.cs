using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Target_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int R = input[0];
            int C = input[1];
            string snakeString = Console.ReadLine();
            int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] matrix = new char[R][];
            MatrixFill(matrix, R, C, snakeString);
            int shotRow = shot[0];
            int shotCol = shot[1];
            int range = shot[2];
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    int condition = (shotRow - rows)* (shotRow - rows) + (shotCol - cols)* (shotCol - cols);
                    if (condition <= (range*range))
                    {
                        matrix[rows][cols] = ' ';
                    }
                }
            }
            for (int i = 0; i < R - 1; i++)
            {
                for (int rows = R - 2; rows >= 0; rows--)
                {
                    for (int cols = C - 1; cols >= 0; cols--)
                    {
                        if ((matrix[rows][cols] != ' ') && (matrix[rows + 1][cols] == ' '))
                        {
                            char temp = matrix[rows][cols];
                            matrix[rows][cols] = matrix[rows + 1][cols];
                            matrix[rows + 1][cols] = temp;
                        }
                    }
                }
            }
            for (int rows = 0; rows < R; rows++)
            {
                Console.WriteLine(string.Join("", matrix[rows]));
            }
        }

        private static void MatrixFill(char[][] matrix, int R, int C, string snakeString)
        {
            for (int rows = 0; rows < R; rows++)
            {
                matrix[R - 1 - rows] = new char[C];
                for (int cols = 0; cols < C; cols++)
                {
                    int evenRow = matrix.Length - 1 - rows;
                    int evenRowCol = matrix[R - 1 - rows].Length - 1 - cols;
                    int snakeStrInd = (rows * matrix[R - 1 - rows].Length + cols) % snakeString.Length;
                    if (rows % 2 == 0)
                    {
                        matrix[evenRow][evenRowCol] = snakeString[snakeStrInd];
                    }
                    else
                    {
                        matrix[R - 1 - rows][cols] = snakeString[snakeStrInd];
                    }
                }
            }
        }
    }
}

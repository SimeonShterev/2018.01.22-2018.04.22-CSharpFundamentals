using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubiks_Matrix
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
                matrix[rows] = new int[C];
                for (int cols = 0; cols < C; cols++)
                {
                    filler++;
                    matrix[rows][cols] = filler;
                }
            }
            int commandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsNum; i++)
            {
                string[] command = Console.ReadLine().Split();
                string direction = command[1];

                switch (direction)
                {
                    case "left":
                        RowMove(command, matrix);
                        break;
                    case "right":
                        RowMove(command, matrix);
                        break;
                    case "up":
                        ColumnMove(command, matrix);
                        break;
                    case "down":
                        ColumnMove(command, matrix);
                        break;
                }
            }
            filler = 0;
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    filler++;
                    if (matrix[rows][cols] == filler)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        SwapElements(matrix, rows, cols, filler, R, C);
                        
                    }
                }
            }

        }

        private static void SwapElements(int[][] matrix, int rows, int cols, int filler, int R, int C)
        {
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (matrix[r][c] == filler)
                    {
                        int temp = matrix[rows][cols];
                        matrix[rows][cols] = matrix[r][c];
                        matrix[r][c] = temp;
                        Console.WriteLine($"Swap ({rows}, {cols}) with ({r}, {c})");
                        return;
                    }
                }
            }
        }

        private static void ColumnMove(string[] command, int[][] matrix)
        {
            string direction = command[1];
            int moves = int.Parse(command[2]);
            int colNum = int.Parse(command[0]);
            int colElements = matrix.GetLength(0);
            if (direction == "down")
            {
                moves = colElements - moves;
            }
            int[] colCopy = new int[colElements];
            for (int i = 0; i < colElements; i++)
            {
                int pos = (i + moves) % colElements;
                colCopy[i] = matrix[pos][colNum];
            }
            for (int i = 0; i < colElements; i++)
            {
                matrix[i][colNum] = colCopy[i];
            }
        }

        private static void RowMove(string[] command, int[][] matrix)
        {
            string direction = command[1];
            int moves = int.Parse(command[2]);
            int rowNum = int.Parse(command[0]);
            int rowElements = matrix.GetLength(0);
            if (direction == "right")
            {
                moves = rowElements - moves;
            }
            int[] rowCopy = new int[rowElements];
            for (int i = 0; i < rowElements; i++)
            {
                int pos = (i + moves) % rowElements;
                rowCopy[i] = matrix[rowNum][pos];
            }
            for (int i = 0; i < rowElements; i++)
            {
                matrix[rowNum][i] = rowCopy[i];
            }
        }
    }
}

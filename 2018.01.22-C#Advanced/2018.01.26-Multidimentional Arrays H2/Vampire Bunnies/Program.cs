using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int R = input[0];
            int C = input[1];
            char[][] matrix = new char[R][];
            Queue<int> personPosition = new Queue<int>();
            for (int rows = 0; rows < R; rows++)
            {
                string inputRow = Console.ReadLine();
                matrix[rows] = new char[inputRow.Length];
                for (int cols = 0; cols < C; cols++)
                {
                    matrix[rows][cols] = inputRow[cols];
                    if (matrix[rows][cols] == 'P')
                    {
                        personPosition.Enqueue(rows);
                        personPosition.Enqueue(cols);
                    }
                }
            }
            string moves = Console.ReadLine();
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'U':
                        PlayerMoveUp(matrix, R, C, personPosition);
                        break;
                   case 'D':
                       PlayerMoveDown(matrix, R, C, personPosition);
                       break;
                   case 'L':
                       PlayerMoveLeft(matrix, R, C, personPosition);
                       break;
                   case 'R':
                       PlayerMoveRight(matrix, R, C, personPosition);
                       break;
                }
            }
        }

        private static void PlayerMoveRight(char[][] matrix, int R, int C, Queue<int> personPosition)
        {
            int win = 0;
            int loss = 0;
            int personRow = personPosition.Dequeue();
            int personCol = personPosition.Dequeue();
            if (personCol + 1 > C-1)
            {
                win++;
                matrix[personRow][personCol] = '.';
            }
            else
            {
                if (matrix[personRow][personCol + 1] == 'B')
                {
                    matrix[personRow][personCol] = '.';
                    personCol++;
                    loss++;
                }
                else
                {
                    char temp = matrix[personRow][personCol];
                    matrix[personRow][personCol] = matrix[personRow][personCol + 1];
                    matrix[personRow][personCol + 1] = temp;
                    personCol++;
                }
            }
            BunniesExpand(matrix, R, C);
            personPosition.Enqueue(personRow);
            personPosition.Enqueue(personCol);
            if (win != 0)
            {
                PrintVictory(personCol, personRow, matrix);
            }
            if (matrix[personRow][personCol] == 'B')
            {
                PrintDefeat(personCol, personRow, matrix);
            }
        }

        private static void PlayerMoveLeft(char[][] matrix, int R, int C, Queue<int> personPosition)
        {
            int win = 0;
            int loss = 0;
            int personRow = personPosition.Dequeue();
            int personCol = personPosition.Dequeue();
            if (personCol - 1 < 0)
            {
                win++;
                matrix[personRow][personCol] = '.';
            }
            else
            {
                if (matrix[personRow][personCol-1] == 'B')
                {
                    matrix[personRow][personCol] = '.';
                    personCol--;
                    loss++;
                }
                else
                {
                    char temp = matrix[personRow][personCol];
                    matrix[personRow][personCol] = matrix[personRow][personCol-1];
                    matrix[personRow][personCol-1] = temp;
                    personCol--;
                }
            }
            BunniesExpand(matrix, R, C);
            personPosition.Enqueue(personRow);
            personPosition.Enqueue(personCol);
            if (win != 0)
            {
                PrintVictory(personCol, personRow, matrix);
            }
            if (matrix[personRow][personCol] == 'B')
            {
                PrintDefeat(personCol, personRow, matrix);
            }
        }

        private static void PlayerMoveDown(char[][] matrix, int R, int C, Queue<int> personPosition)
        {
            int win = 0;
            int loss = 0;
            int personRow = personPosition.Dequeue();
            int personCol = personPosition.Dequeue();
            if (personRow + 1 > R-1)
            {
                win++;
                matrix[personRow][personCol] = '.';
            }
            else
            {
                if (matrix[personRow + 1][personCol] == 'B')
                {
                    matrix[personRow][personCol] = '.';
                    personRow = personRow + 1;
                    loss++;
                }
                else
                {
                    char temp = matrix[personRow][personCol];
                    matrix[personRow][personCol] = matrix[personRow + 1][personCol];
                    matrix[personRow + 1][personCol] = temp;
                    personRow = personRow + 1;
                }
            }
            BunniesExpand(matrix, R, C);
            personPosition.Enqueue(personRow);
            personPosition.Enqueue(personCol);
            if (win != 0)
            {
                PrintVictory(personCol, personRow, matrix);
            }
            if (matrix[personRow][personCol] == 'B')
            {
                PrintDefeat(personCol, personRow, matrix);
            }
        }

        private static void PlayerMoveUp(char[][] matrix, int R, int C, Queue<int> personPosition)
        {
            int win = 0;
            int loss = 0;
            int personRow = personPosition.Dequeue();
            int personCol = personPosition.Dequeue();
            if (personRow - 1 < 0)
            {
                win++;
                matrix[personRow][personCol] = '.';
            }
            else
            {
                if (matrix[personRow - 1][personCol] == 'B')
                {
                    matrix[personRow][personCol] = '.';
                    personRow = personRow - 1;
                    loss++;
                }
                else
                {
                    char temp = matrix[personRow][personCol];
                    matrix[personRow][personCol] = matrix[personRow - 1][personCol];
                    matrix[personRow - 1][personCol] = temp;
                    personRow = personRow - 1;
                }
            }
            BunniesExpand(matrix, R, C);
            personPosition.Enqueue(personRow);
            personPosition.Enqueue(personCol);
            if (win != 0)
            {
                PrintVictory(personCol, personRow, matrix);
            }
            if (matrix[personRow][personCol] == 'B')
            {
                PrintDefeat(personCol, personRow, matrix);
            }
        }

        private static void PrintDefeat(int personCol, int personRow, char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine($"dead: {personRow} {personCol}");
            Environment.Exit(0);
        }

        private static void PrintVictory(int personCol, int personRow, char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine($"won: {personRow} {personCol}");
            Environment.Exit(0);
        }

        private static void BunniesExpand(char[][] matrix, int R, int C)
        {
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    if (rows == 0 && cols == 0 && matrix[rows][cols] == 'B')                                           //corner
                    {
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == 0 && cols == C - 1 && matrix[rows][cols] == 'B')                                         //corner
                    {
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && cols == 0 && matrix[rows][cols] == 'B')                                    //corner
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && cols == C - 1 && matrix[rows][cols] == 'B')                                  //corner
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == 0 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        continue;
                    }
                    if (cols == 0 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (cols == C - 1 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (matrix[rows][cols] == 'B')                                             //center
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                }
            }
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    if (matrix[rows][cols] == 'b')
                        matrix[rows][cols] = 'B';
                }
            }
        }
    }
}

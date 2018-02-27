using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int nikoRow = 0;
            int samRow = 0;
            int samCol = 0;
            Queue<string> enemyInfo = new Queue<string>();
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                if (matrix[row].Contains('N'))
                    nikoRow = row;
                if (matrix[row].Contains('S'))
                {
                    samRow = row;
                    samCol = FindSamCol(matrix[row]);
                }
                if (matrix[row].Contains('b') || matrix[row].Contains('d'))
                {
                    FindEnemys(enemyInfo, matrix[row], row);
                }
            }
            char[] moves = Console.ReadLine().ToCharArray();
            int counter = 0;
            while(true)
            {
                counter++;
                EnemiesMove(enemyInfo, matrix);
                MatrixChanges(enemyInfo, matrix);
                char currentMove = moves[counter];
                switch(currentMove)
                {
                    case 'U':
                        UpMove()
                        break;
                    case 'D':
                        DownMove()
                        break;
                    case 'L':
                        UpMove()
                        break;
                    case 'R':
                        UpMove()
                        break;
                }
            }
            int debug = 0;
        }

        private static void MatrixChanges(Queue<string> enemyInfo, char[][] matrix)
        {
            
        }

        private static void EnemiesMove(Queue<string> enemyInfo, char[][] matrix)
        {
            for (int enemy = 0; enemy < enemyInfo.Count; enemy+=3)
            {
                char enemyType = enemyInfo.Dequeue()[0];
                int row = enemyInfo.Dequeue()[0];
                int col = enemyInfo.Dequeue()[0];
                if (enemyType=='b' && col< matrix[0].Length - 2)
                {
                    col++;
                }
                if (enemyType == 'b' && col == matrix[0].Length - 2)
                {
                    enemyType = 'd';
                    col++;
                }
                enemyInfo.Enqueue(enemyType.ToString());
                enemyInfo.Enqueue(row.ToString());
                enemyInfo.Enqueue(col.ToString());
            }
        }

        private static void FindEnemys(Queue<string> enemyInfo, char[] matrixRow, int row)
        {
            for (int col = 0; col < matrixRow.Length; col++)
            {
                if (matrixRow[col] == 'b' || matrixRow[col]=='d')
                {
                    enemyInfo.Enqueue(matrixRow[col].ToString());
                    enemyInfo.Enqueue(row.ToString());
                    enemyInfo.Enqueue(col.ToString());
                }
            }
        }

        private static int FindSamCol(char[] matrixRow)
        {
            int samCol = 0;
            for (int col = 0; col < matrixRow.Length; col++)
            {
                if (matrixRow[col] == 'S')
                {
                    samCol = col;
                    return samCol;
                }
            }
            return samCol;
        }
    }
}

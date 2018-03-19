using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsNum = input[0];
            int colsNum = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[][] matrix = new string[rowsNum][];
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new string[colsNum];
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    char first =alphabet[rows];
                    char second = alphabet[rows+cols];
                    matrix[rows][cols] = $"{first}{second}{first}";
                }
            }
            foreach(string[] rows in matrix)
            {
                Console.WriteLine(string.Join(" ", rows));
            }
        }
    }
}

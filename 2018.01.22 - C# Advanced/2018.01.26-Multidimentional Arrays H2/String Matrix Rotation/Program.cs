using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rotationInput = Console.ReadLine().Split(new char[] { ')', '(' });
            int rotation = int.Parse(rotationInput[1]);
            rotation = rotation % 360;
            string input;
            int longestWord = -1;
            List<string> words = new List<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                words.Add(input);
                if (input.Length > longestWord)
                    longestWord = input.Length;
            }
            for (int i = 0; i < words.Count; i++)
            {
                int mismatch = longestWord - words[i].Length;
                words[i] += new string(' ', mismatch);
            }
            switch (rotation)
            {
                case 0:
                    RotateTo_0_Degree(words);
                    break;
                case 90:
                    RotateTo_90_Degree(words);
                    break;
                case 180:
                    RotateTo_180_Degree(words);
                    break;
                case 270:
                    RotateTo_270_Degree(words);
                    break;
            }
        }

        private static void RotateTo_90_Degree(List<string> words)
        {
            int R = words[0].Length;
            int C = words.Count;
            char[,] matrix = new char[R, C];
            for (int cols = 0; cols < C; cols++)
            {
                for (int rows = 0; rows < R; rows++)
                {
                    matrix[rows, cols] = words[C - 1 - cols][rows];
                }
            }
            for (int row = 0; row < R; row++)
            {
                for (int col = 0; col < C; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void RotateTo_180_Degree(List<string> words)
        {
            for (int i = words.Count - 1; i >= 0; i--)
            {
                char[] reversedWord = words[i].ToCharArray().Reverse().ToArray();
                Console.WriteLine(string.Join("", reversedWord));
            }
        }

        private static void RotateTo_270_Degree(List<string> words)
        {
            int R = words[0].Length;
            int C = words.Count;
            char[,] matrix = new char[R, C];
            for (int cols = 0; cols < C; cols++)
            {
                for (int rows = 0; rows < R; rows++)
                {
                    matrix[rows, cols] = words[cols][R - 1 - rows];
                }
            }
            for (int row = 0; row < R; row++)
            {
                for (int col = 0; col < C; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void RotateTo_0_Degree(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

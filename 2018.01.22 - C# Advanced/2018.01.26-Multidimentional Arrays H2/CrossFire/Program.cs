using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossFire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int inputRow = input[0];
            int inputCol = input[1];
            List<List<int>> matrix = new List<List<int>>();
            int filler = 0;
            for (int rows = 0; rows < inputRow; rows++)
            {
                matrix.Add(new List<int>());
                for (int cols = 0; cols < inputCol; cols++)
                {
                    filler++;
                    matrix[rows].Add(filler);
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] commandTokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                RemoveElements(commandTokens, matrix);
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void RemoveElements(int[] commandTokens, List<List<int>> matrix)
        {
            int R = commandTokens[0];
            int C = commandTokens[1];
            int radius = commandTokens[2];
            Queue<int> numToRemove = new Queue<int>();
            for (int rad = radius; rad >0; rad--)
            {
                try
                {
                    numToRemove.Enqueue(matrix[R + rad][C]);
                }
                catch (ArgumentOutOfRangeException) { }
                try
                {
                    numToRemove.Enqueue(matrix[R][C + rad]);
                }
                catch (ArgumentOutOfRangeException) { }
                try
                {
                    numToRemove.Enqueue(matrix[R - rad][C]);
                }
                catch (ArgumentOutOfRangeException) { }
            }
            try
            {
                numToRemove.Enqueue(matrix[R][C]);
            }
            catch (ArgumentOutOfRangeException) { }
            for (int rad = radius; rad > 0; rad--)
            {
                try
                {
                    numToRemove.Enqueue(matrix[R][C-rad]);
                }
                catch (ArgumentOutOfRangeException) { }
            }
            while (numToRemove.Count != 0)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if(numToRemove.Count != 0 && matrix[row].Contains(numToRemove.Peek()))
                    matrix[row].Remove(numToRemove.Dequeue());
                }
            }
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                    matrix.RemoveAt(row);
            }
        }
    }
}

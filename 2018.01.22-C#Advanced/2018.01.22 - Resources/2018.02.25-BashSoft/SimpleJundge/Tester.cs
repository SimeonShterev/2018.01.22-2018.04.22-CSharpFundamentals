using BashSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleJundge
{
    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            string mismatch = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatch;
            string mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

            PrintOutput(mismatch, hasMismatch, mismatchPath);
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexof = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexof);
            string finalPath = directoryPath + @"Mismatch.txt";
            return finalPath;
        }
    }
}

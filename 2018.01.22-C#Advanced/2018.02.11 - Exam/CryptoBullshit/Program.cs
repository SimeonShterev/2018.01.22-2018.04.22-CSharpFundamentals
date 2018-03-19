using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoBullshit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\[|{)\D*?(\d+?)\D*?(\]|})";
            StringBuilder input = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string lineInput = Console.ReadLine();
                input.Append(lineInput);
            }
            Queue<int> lengthsOfMatches = new Queue<int>();
            string textToDecode = input.ToString();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(textToDecode);
            List<string> data = new List<string>();
            Predicate<string> predicate = s => (s.StartsWith("[") && s.EndsWith("]")) || (s.StartsWith("{") && s.EndsWith("}"));
            foreach (Match match in matches)
            {
                string strMatch = match.ToString();
                if(predicate(strMatch))
                {
                    int count = match.Groups[2].Value.Count();
                    if(count%3==0)
                    {
                        string numsForASCII = match.Groups[2].Value;
                        data.Add(numsForASCII);
                        int lenght = strMatch.Length;
                        lengthsOfMatches.Enqueue(lenght);
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            foreach (var token in data)
            {
                int length = lengthsOfMatches.Dequeue();
                char[] charRepresentation = token.ToCharArray();
                for (int i = 0; i < charRepresentation.Length; i+=3)
                {
                    int asciiNumber = int.Parse(charRepresentation[i].ToString() + charRepresentation[i + 1].ToString() + charRepresentation[i + 2].ToString()) - length;
                    char asciiSymbol = (char)asciiNumber;
                    result.Append(asciiSymbol);
                }
            }
            Console.WriteLine(result);
            int debug = 0;
        }
    }
}

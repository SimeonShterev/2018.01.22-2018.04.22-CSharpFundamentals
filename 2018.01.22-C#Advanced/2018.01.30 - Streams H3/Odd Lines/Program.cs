using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("sample.txt");
            using (reader)
            {
                int lineCounter = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineCounter % 2 != 0)
                        Console.WriteLine(line);
                    line = reader.ReadLine();
                    lineCounter++;
                }
            }
        }
    }
}

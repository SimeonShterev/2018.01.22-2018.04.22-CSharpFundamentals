using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../sample.txt");
            StreamWriter writer = new StreamWriter("../../result.txt");
            using (reader)
            {
                using (writer)
                {
                    int lineCounter = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineCounter}: {line}");
                        line = reader.ReadLine();
                        lineCounter++;
                    }
                }
            }
        }
    }
}

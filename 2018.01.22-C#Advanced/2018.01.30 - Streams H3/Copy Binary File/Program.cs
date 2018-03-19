using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream("../../copyMe.png", FileMode.Open))
            {
                using(var destinationToGo = new FileStream("../../copiedFile.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while(true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destinationToGo.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}

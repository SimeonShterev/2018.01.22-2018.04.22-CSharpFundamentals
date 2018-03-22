using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
			IStreamable musicFile = new Music("ToniDa4eva", "Moreto", 210, 300);
			StreamProgressInfo streamProgressInfo = new StreamProgressInfo(musicFile);
			int size1 = streamProgressInfo.CalculateCurrentPercent();
			Console.WriteLine(size1);
			IStreamable File = new File("PeshoFile", 100, 500);
			streamProgressInfo = new StreamProgressInfo(File);
			int size2 = streamProgressInfo.CalculateCurrentPercent();
			Console.WriteLine(size2);
		}
    }
}

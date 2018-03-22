using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
		private IStreamable someFile;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable someFile)
        {
			this.someFile = someFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.someFile.BytesSent * 100) / this.someFile.Length;
        }
    }
}

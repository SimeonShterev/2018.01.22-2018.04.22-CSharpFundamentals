using StorageMaster.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			Engine engine = new Engine();
			engine.Run();
		}
    }
}

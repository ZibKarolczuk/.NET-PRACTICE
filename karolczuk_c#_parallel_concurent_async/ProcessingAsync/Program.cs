using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingAsync
{
    class Program
    {
        public static async Task Main(string[] args)
        {
			//await SineCosineDegrees.Display();
			//await SineCosineDegreesAsync.Display();

			await SineCosineDegreesAsyncRun.Display();
        }
    }
}

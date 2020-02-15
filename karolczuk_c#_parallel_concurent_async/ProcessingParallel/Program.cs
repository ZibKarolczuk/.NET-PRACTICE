using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingParallel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Parallel Programming World!");

            ParallelSimple.DisplaySynchronousEnumarating();
			ParallelSimple.DisplayParallel();
            await ParallelSimple.DisplayParallelWithAwait();
		}
	}
}

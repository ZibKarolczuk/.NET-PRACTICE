using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingAsync
{
	class SineCosineDegreesAsyncRun
	{
        public static async Task Display()
        {
            var tasks = new List<Task>();
            var watch = Stopwatch.StartNew();

            tasks.Add(CosineAngleConsoleAsync(270, 60));
            tasks.Add(SineAngleConsoleAsync(410, 45));

            await Task.WhenAll(tasks);
            var elapsedMs = watch.ElapsedMilliseconds;

			Console.WriteLine($"\n   Elapsed time {elapsedMs / 1000} sec");
        }

		public static async Task CosineAngleConsoleAsync(int timeInterval, int angle)
        {
            await Task.Run(() =>
            {
				for (var i = 0; i < angle; i++)
				{
					Thread.Sleep(timeInterval);
					Console.WriteLine($" .. cos {i}* = {Math.Cos((i * Math.PI) / 180)}");
				};
			});
        }

        public static async Task SineAngleConsoleAsync(int timeInterval, int angle)
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < angle; i++)
                {
                    Thread.Sleep(timeInterval);
                    Console.WriteLine($"  . sin {i}* = {Math.Sin((i * Math.PI) / 180)}");
                };

            });

		}
    }
}

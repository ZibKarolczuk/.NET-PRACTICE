using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingAsync
{
	class SineCosineDegreesAsync
	{
        public static async Task Display()
        {
            var ca1 = CosineAngleConsoleAsync(270, 60);
            var ca2 = SineAngleConsoleAsync(410, 45);

            //for (var i = 2; i < 10; i++)
            //{
            //	Thread.Sleep(i * 335);
            //	Console.WriteLine("...");
            //}

            //await ca1;
            //await ca2;

            var allTasks = new List<Task>() { ca1, ca2 };
            Task finished = await Task.WhenAny(allTasks);

            if (finished == ca1)
            {
                Console.WriteLine("FINISHED WITH TASKS FOR COSINE");
            }
            else {
                Console.WriteLine("FINISHER WITH TASKS FOR SINES");
            }
		}

		public static async Task CosineAngleConsoleAsync(int timeInterval, int angle)
        {
            await Task.Factory.StartNew(() =>
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
            await Task.Factory.StartNew(() =>
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

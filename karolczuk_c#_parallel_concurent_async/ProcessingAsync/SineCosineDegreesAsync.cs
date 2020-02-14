using System;
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

			for (var i = 2; i < 10; i++)
			{
				Thread.Sleep(i * 335);
				Console.WriteLine("...");
			}

			await ca1;
			await ca2;
		}

		public static async Task CosineAngleConsoleAsync(int timeInterval, int angle)
        {
            await Task.Factory.StartNew(() =>
            {
				for (var i = 0; i < angle; i++)
				{
					Thread.Sleep(270);
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
                    Thread.Sleep(310);
                    Console.WriteLine($"  . sin {i}* = {Math.Sin((i * Math.PI) / 180)}");
                };

            });

		}
    }
}

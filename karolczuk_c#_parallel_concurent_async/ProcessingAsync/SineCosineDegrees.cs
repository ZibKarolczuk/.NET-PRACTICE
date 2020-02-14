using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingAsync
{
	class SineCosineDegrees
	{

        public static async Task Display()
        {
            var ca1 = Task.Run(SineAngleConsole);
            var ca2 = Task.Run(CosineAngleConsole);

            for (var i = 2; i < 10; i++)
            {
                Thread.Sleep(i * 335);
                Console.WriteLine("...");
            }

            await ca1;
            await ca2;
        }

        public static void CosineAngleConsole()
        {
            for (var i = 0; i < 61; i++)
            {
                Thread.Sleep(270);
                Console.WriteLine($" .. cos {i}* = {Math.Cos((i * Math.PI) / 180)}");
            };

        }

        public static void SineAngleConsole()
        {
            for (var i = 0; i < 61; i++)
			{
                Thread.Sleep(310);
                Console.WriteLine($"  . sin {i}* = {Math.Sin((i * Math.PI) / 180)}");
            };

        }
    }
}

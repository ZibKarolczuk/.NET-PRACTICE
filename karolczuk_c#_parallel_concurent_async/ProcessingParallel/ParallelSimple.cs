using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingParallel
{
	public static class ParallelSimple
	{
		public static void Display() {
			var angles = new List<int>() { 0, 30, 45, 60, 90, 120, 135, 150, 180, 210, 225, 240, 270, 300, 315, 330, 360 };
			Parallel.ForEach<int>(angles, new ParallelOptions { MaxDegreeOfParallelism = 3 }, angle =>
				{
					Console.WriteLine($" cos {angle}* = {Math.Cos((angle * Math.PI) / 180)}");
					Thread.Sleep(5000);
				});
		}
	}
}

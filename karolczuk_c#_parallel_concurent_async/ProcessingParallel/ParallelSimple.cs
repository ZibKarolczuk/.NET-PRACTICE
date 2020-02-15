using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingParallel
{
	public static class ParallelSimple
	{
		static List<int> ANGLES = new List<int>() { 0, 30, 45, 60, 90, 120, 135, 150, 180, 210, 225, 240, 270, 300, 315, 330, 360 };
		static int MAX_THREADS = 3;

		public static void DisplaySynchronousEnumarating() {
			Console.WriteLine("\nFirst Solution using synchronous approach");
			var watch = Stopwatch.StartNew();

			for (var angle= 0; angle < ANGLES.Count; angle++)
			{
				ExecuteForAngle(angle);
			}

			var elapsedMs = watch.ElapsedMilliseconds;
			Console.WriteLine($"Elapsed time in ms = {elapsedMs}");
		}

		public static void DisplayParallel() {
			Console.WriteLine("\nSecond Solution keep simple only with Parallel");
			var watch = Stopwatch.StartNew();

			Parallel.ForEach<int>(ANGLES, new ParallelOptions { MaxDegreeOfParallelism = MAX_THREADS }, angle =>
					{
						ExecuteForAngle(angle);
					});

			var elapsedMs = watch.ElapsedMilliseconds;
			Console.WriteLine($"Elapsed time in ms = {elapsedMs}");
		}

		public static async Task DisplayParallelWithAwait()
		{
			Console.WriteLine("\nThird solution - Probably overengineered using ASYNC on PARALLEL?");
			var watch = Stopwatch.StartNew();

			await Task.Run(() => {

				Parallel.ForEach<int>(ANGLES, new ParallelOptions { MaxDegreeOfParallelism = MAX_THREADS }, angle =>
				{
					ExecuteForAngle(angle);
				});

			});

			var elapsedMs = watch.ElapsedMilliseconds;
			Console.WriteLine($"Elapsed time in ms = {elapsedMs}");
		}

		public static void ExecuteForAngle(int angle) {
			Console.WriteLine($" cos {angle}* = {Math.Cos((angle * Math.PI) / 180)} [Thread = {Thread.CurrentThread.ManagedThreadId}]");
		}
	}
}

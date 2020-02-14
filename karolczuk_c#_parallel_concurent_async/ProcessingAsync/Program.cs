using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var x = PrintSinOfAngleAsync();
            Console.WriteLine(await x);
            Console.WriteLine("Hello");
            //PrintSinOfAngleAsync2();

            //Task.WhenAll();
        }

        public static async Task<string> PrintSinOfAngleAsync()
        {
            //for (var i = 0; i< 181; i++)
            //{
                Thread.Sleep(1000);
            //Console.WriteLine($"Sine of angle {i} is {Math.Sin((i * Math.PI) / 180)}");
            return "Jarek Kaczynski";

            //};

        }

        public static async Task PrintSinOfAngleAsync2()
        {
            for (var i = 0; i < 181; i++)
            {
                Thread.Sleep(30);
                Console.WriteLine($"Cosine of angle {i} is {Math.Cos((i * Math.PI) / 180)}");
            };

        }
    }
}

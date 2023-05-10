using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncPractice
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 25; i++)
            {
                if (i % 2 == 0)
                {
                    tasks.Add(DisplayEvenAsync(i));
                }
                else
                {
                    tasks.Add(DisplayOddAsync(i));
                }
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        static async Task DisplayEvenAsync(int value)
        {
            await Task.Delay(150);
            await Task.Run(() => Console.WriteLine("Even" + (value * 10)));  
        }

        static async Task DisplayOddAsync(int value)
        {
            await Task.Delay(150);
            await Task.Run(() => Console.WriteLine("Odd" + (value * 10 + 1)));    
        }
    }
}

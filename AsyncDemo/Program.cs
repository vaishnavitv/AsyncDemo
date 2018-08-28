using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //await says: whatever I am running now, push to background, continue execution; If background is completed, run whatever was deferred.

            //DemoAwait();
            DemoAwaitTwo();
            //DemoAwaitMultiple();
            Console.WriteLine("Resume Execution ...");

            Console.WriteLine("Press Key to End Program.");
            Console.ReadLine();
        }

        static async void DemoAwait()
        {
            //int result = WaitForSeconds(2); //Would block!
            int result = await WaitForSecondsAsync(2);
            Console.WriteLine($"Awaited Result: {result}");
        }

        static async void DemoAwaitTwo()
        {
            int result = await WaitForSecondsAsync(2) + await WaitForSecondsAsync(3);
            Console.WriteLine($"Awaited Combined Result: {result}");
        }

        static void DemoAwaitMultiple() //Not Async!
        {
            int n = 10;
            Task[] tasks = new Task[n];
            for (; n > 0; --n)
            {
                tasks[n - 1] = WaitForSecondsAsync(n);
            }
            Task.WaitAll(tasks); //Roughly equivalent to: await tasks[0]; await tasks[1]; ... await tasks[n - 1];
        }

        static Task<int> WaitForSecondsAsync(int n)
        {
            return Task.Factory.StartNew(() => WaitForSeconds(n));
        }

        static int WaitForSeconds(int n)
        {
            Thread.Sleep(n * 1000);
            Console.WriteLine($"Synchronously Waited for: {n}");
            return n;
        }

    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    private static bool running = true;

    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Task printTask = PrintNumbersAsync();
        Task messageTask = ShowMessagePeriodicallyAsync();

        await Task.WhenAll(printTask, messageTask);
    }

    static async Task PrintNumbersAsync()
    {
        while (running)
        {
            await semaphore.WaitAsync();
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("10");
            }
            finally
            {
                semaphore.Release();
            }
            await Task.Delay(10);
        }
    }

    static async Task ShowMessagePeriodicallyAsync()
    {
        while (running)
        {
            await Task.Delay(5000);
            await semaphore.WaitAsync();
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNeo, you are the chosen one");
            }
            finally
            {
                semaphore.Release();
            }
            await Task.Delay(5000);
        }
    }
}
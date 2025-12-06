using Problem.Functions;
using Problem.Lab1.IntegralCalculations.Factory;
using Problem.Lab2;
using Problem.Lab3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var functions = new List<IFunctionDeterminable>
        {
            new LinearFuction(),
            new QuadraticFunction(),
            new SinFunction()
        };

        var ranges = new List<(double start, double end, string name)>
        {
            (0, 10,  "Range 1"),
            (3, 12,  "Range 2"),
            (5, 14,  "Range 3")
        };

        Console.WriteLine("Select processing method:");
        Console.WriteLine("Q: BackgroundWorker");
        Console.WriteLine("W: TPL");
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.Q:
                Console.WriteLine("Worker selected");
                foreach (var f in functions)
                    await RunWorkersForFunction(f, ranges);

                break;

            case ConsoleKey.W:
                Console.WriteLine("TPL selected");
                var tplProcessor = new TPLTaskSolution();
                await tplProcessor.CalculateIntegralsAsync(functions, IntegrationAlgorithm.Midpoint);
                Console.WriteLine("TPL calculations completed.");
                break;

            default:
                Console.WriteLine("Unknown option selected.");
                break;
        }

        Console.WriteLine("\nAll calculations finished.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static async Task RunWorkersForFunction(IFunctionDeterminable function,
                                            List<(double start, double end, string name)> ranges)
    {
        var bw = new BackgroundWorkerInstantiator(ranges);
        bw.InitializeWorkers();
        bw.Run(function, 100000);

        while (!bw.AllWorkersCompleted())
            await Task.Delay(100);
    }
}

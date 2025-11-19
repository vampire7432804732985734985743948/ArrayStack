using Problem.Functions;
using Problem.Lab1;
using Problem.Lab1.IntegralCalculations;
using Problem.Lab1.IntegralCalculations.Factory;
using Problem.Lab2;
using Problem.Lab3;
using System.ComponentModel;


static void SetDelay(BackgroundWorkerInstantiator worker)
{
    if (worker != null)
    {
        while (true)
        {
            if (worker.AllWorkersCompleted())
                break;
            Thread.Sleep(1000);
        }
    }
}

Console.WriteLine("Choose BackgroundWorker: Q");
Console.WriteLine("Choose TPL: W");
ConsoleKey choice = Console.ReadKey().Key;
List<IFunctionDeterminable> functions = new List<IFunctionDeterminable>
{
    new LinearFuction(),
    new QuadraticFunction(),
    new SinFunction(),
};
switch (choice)
{
    case ConsoleKey.Q:
    break;
    case ConsoleKey.W:
        TPLTaskSolution integralAreaCalculation = new TPLTaskSolution();
        await integralAreaCalculation.CalculateIntegralsAsync(functions, IntegrationAlgorithm.Midpoint);
    break;

}


Console.WriteLine("\nAll calculations completed.");
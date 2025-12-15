using Problem.Functions;
using Problem.Lab1.IntegralCalculations.Factory;
using Problem.Lab3;
using Problem.Lab4;
using Problem.StudentDataBase.TechnicalStuff;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var functions = new List<IFunctionDeterminable>
        {
            new SinFunction(),
            new ParabolicFunction(),
            new LinearFuction(),
            new QuadraticFunction(),
            new DirectProportionalityFunction(),
        };
        double start = ConsoleInterfaceManager.ReadDouble("Enter the start of the interval: ");
        double end = ConsoleInterfaceManager.ReadDouble("Enter the end of the interval: ");
        int iterations = ConsoleInterfaceManager.ReadInt("Enter the number of iterations: ");

        var tplProcessor = new TPLTaskSolution(start, end, iterations);
        await tplProcessor.CalculateIntegralsAsync(functions, IntegrationAlgorithm.Midpoint);
    }
}



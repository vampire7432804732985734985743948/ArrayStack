using Problem.Functions;
using Problem.Lab1.IntegralCalculations.Factory;
using Problem.Lab3;
using Problem.Lab4;
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
        var tplProcessor = new TPLTaskSolution();
        await tplProcessor.CalculateIntegralsAsync(functions, IntegrationAlgorithm.Midpoint);
    }
}



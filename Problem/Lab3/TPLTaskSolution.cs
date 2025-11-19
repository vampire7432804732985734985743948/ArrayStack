using Problem.Functions;
using Problem.Lab1;
using Problem.Lab1.IntegralCalculations;
using Problem.Lab1.IntegralCalculations.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab3
{
    internal class TPLTaskSolution
    {
        public async Task CalculateIntegralsAsync(List<IFunctionDeterminable> functions, IntegrationAlgorithm integralCalculationAlgorithm)
        {
            Console.WriteLine($"Calculation method: {integralCalculationAlgorithm.ToString()}");

            IProgress<string> progress = new Progress<string>(message =>
            {
                Console.WriteLine(message);
            });

            var tasks = functions.Select(f => Task.Run(() =>
            {
                double start = 0;
                double end = 10;
                int iterations = 100;

                IProgress<double> taskProgress = new Progress<double>(p =>
                {
                    progress.Report($"{f.Name}: {p}% completed");
                });

                var calculator = SetCalculationAlgorithm(integralCalculationAlgorithm);

                calculator.StartPosition = start;
                calculator.EndPosition = end;
                calculator.NumberOfIterations = iterations;
                calculator.Progress = taskProgress;

                double result = calculator.GetIntegral(new IntegralMethodRequest(f));

                progress.Report($"Finished {f.Name}, Result = {result}");

                return result;
            })).ToArray();

            await Task.WhenAll(tasks);

            Console.WriteLine("All calculations completed.");
        }

        public FunctionAreaDeterminator SetCalculationAlgorithm(IntegrationAlgorithm algorithm)
        {
            IntegralCalculatorFactory factory = algorithm switch
            {
                IntegrationAlgorithm.Trapezoid => new TrapezoidFactory(),
                IntegrationAlgorithm.Midpoint => new MidpointFactory(),
                IntegrationAlgorithm.Simple => new SimpleIntegralFactory(),
                _ => throw new NotImplementedException()
            };

            return factory.CreateCalculator();
        }
    }
}

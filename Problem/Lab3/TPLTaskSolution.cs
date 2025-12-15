using Problem.Functions;
using Problem.Lab1;
using Problem.Lab1.IntegralCalculations;
using Problem.Lab1.IntegralCalculations.Factory;
using Problem.Lab4;
using Problem.StudentDataBase.TechnicalStuff;
using ScottPlot;
using System;
using System.Collections.Generic;


namespace Problem.Lab3
{
    internal class TPLTaskSolution
    {
        public double Start { get; private set; }

        private double _end;

        public double End
        {
            get { return _end; }
            private set 
            { 
                if (value <= Start)
                {
                    throw new ArgumentException("End position must be greater than start position.");
                }
                _end = value; 
            }
        }
        private int _iterations;

        public int Iterations
        {
            get { return _iterations; }
            private set
            { 
                if (value <= 0)
                {
                    throw new ArgumentException("Number of iterations must be positive.");
                }
                _iterations = value;
            }
        }
        public TPLTaskSolution(double start, double end, int iterations)
        {
            Start = start;
            End = end;
            Iterations = iterations;
        }
        public async Task CalculateIntegralsAsync(List<IFunctionDeterminable> functions, IntegrationAlgorithm integralCalculationAlgorithm)
        {
            ConsoleInterfaceManager.DrawColoredText($"Calculation method: {integralCalculationAlgorithm.ToString()}", ConsoleColor.Green);

            IProgress<string> progress = new Progress<string>(message =>
            {
                Console.WriteLine(message);
            });

            var tasks = functions.Select(f => Task.Run(() =>
            {

                IProgress<double> taskProgress = new Progress<double>(p =>
                {
                    progress.Report($"{f.Name}: {p}% completed");
                    
                });

                var calculator = SetCalculationAlgorithm(integralCalculationAlgorithm);


                calculator.StartPosition = Start;
                calculator.EndPosition = _end;
                calculator.NumberOfIterations = _iterations;
                calculator.Progress = taskProgress;

                double result = calculator.GetIntegral(new IntegralMethodRequest(f));

                progress.Report($"Finished {f.Name}, Result = {result}");

                FunctionImageProvider functionImageProvider = new FunctionImageProvider(calculator.GetXPoints(), calculator.GetYPoints());
                Plot plots = functionImageProvider.GeneratePlot(f);
                functionImageProvider.SavePlot(plots, f.Name, 800, 600);

                return result;
            })).ToArray();

            await Task.WhenAll(tasks);

            ConsoleInterfaceManager.DrawColoredText("All calculations completed.", ConsoleColor.Green);
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

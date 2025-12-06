using Problem.Functions;
using System;

namespace Problem.Lab1
{
    public class NumericalDetermination
    {
        private double _start;
        private double _end;
        private int _iterations;

        public double StartPosition
        {
            get => _start;
            set
            {
                if (value >= EndPosition)
                    throw new ArgumentException("Start must be less than End.");
                _start = value;
            }
        }

        public double EndPosition
        {
            get => _end;
            set
            {
                if (value <= StartPosition)
                    throw new ArgumentException("End must be greater than Start.");
                _end = value;
            }
        }

        public int NumberOfIterations
        {
            get => _iterations;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Iterations must be positive.");
                _iterations = value;
            }
        }

        public NumericalDetermination(double start, double end, int iterations)
        {
            if (start >= end)
                throw new ArgumentException("Start must be less than End.");
            if (iterations <= 0)
                throw new ArgumentException("Iterations must be > 0.");

            _start = start;
            _end = end;
            _iterations = iterations;
        }

        // -------------------------
        //  INTEGRATION METHODS
        // -------------------------

        public double GetIntegralAreaByTrapezoid(IFunctionDeterminable f)
        {
            double width = (_end - _start) / _iterations;
            double sum = 0;

            for (int i = 0; i < _iterations; i++)
            {
                double x0 = _start + i * width;
                double x1 = x0 + width;

                sum += (f.DetermineFunction(x0) + f.DetermineFunction(x1)) * 0.5 * width;
            }

            return sum;
        }

        public double IntegrateMidpoint(IFunctionDeterminable f, EvaluationPoint point)
        {
            double width = (_end - _start) / _iterations;
            double sum = 0;

            for (int i = 0; i < _iterations; i++)
            {
                double x = point switch
                {
                    EvaluationPoint.Left => _start + i * width,
                    EvaluationPoint.Right => _start + (i + 1) * width,
                    EvaluationPoint.Mid => _start + (i + 0.5) * width,
                    _ => throw new ArgumentException("Unknown evaluation point")
                };

                sum += f.DetermineFunction(x) * width;
            }

            return sum;
        }

        public double IntegrateRectangle(IFunctionDeterminable f)
        {
            double width = (_end - _start) / _iterations;
            double sum = 0;

            for (int i = 0; i < _iterations; i++)
            {
                double x = _start + i * width;
                sum += f.DetermineFunction(x) * width;
            }

            return sum;
        }
    }
}

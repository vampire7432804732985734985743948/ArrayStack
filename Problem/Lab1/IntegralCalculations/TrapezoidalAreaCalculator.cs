using Problem.Functions;
using Problem.Lab1.IntegralCalculations;

internal class TrapezoidalAreaCalculator : FunctionAreaDeterminator
{
    public override double GetIntegral(IntegralMethodRequest integralMethodRequest)
    {
        if (integralMethodRequest?.Function == null)
            throw new ArgumentException("No function defined");

        IFunctionDeterminable function = integralMethodRequest.Function;
        double totalArea = 0;
        double width = (EndPosition - StartPosition) / NumberOfIterations;
        int percentDivide = 10;
        for (int i = 0; i < NumberOfIterations; i++)
        {
            double x0 = StartPosition + i * width;
            double x1 = x0 + width;

            if (!XPoints.Contains(x0)) XPoints.Add(x0);
            XPoints.Add(x1);

            totalArea += (function.DetermineFunction(x0) + function.DetermineFunction(x1)) / 2 * width;

            int percent = (i + 1) * 100 / NumberOfIterations;
            if (percent % percentDivide == 0) Progress?.Report(percent);
        }

        return totalArea;
    }
}
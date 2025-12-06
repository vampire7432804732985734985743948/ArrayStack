using Problem.Functions;
using Problem.Lab1.IntegralCalculations;

internal class MidpointAreaCalculator : FunctionAreaDeterminator
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
            double x = StartPosition + (i + 0.5) * width;
            totalArea += function.DetermineFunction(x) * width;
            XPoints.Add(x);
            int percent = (i + 1) * 100 / NumberOfIterations;
            if (percent % percentDivide == 0) Progress?.Report(percent);
        }

        return totalArea;
    }
}
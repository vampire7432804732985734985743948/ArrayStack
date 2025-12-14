using Problem.Functions;
using Problem.Lab1.IntegralCalculations;

internal class TrapezoidalAreaCalculator : FunctionAreaDeterminator
{
    public override double GetIntegral(IntegralMethodRequest integralMethodRequest)
    {
        if (integralMethodRequest?.Function == null)
            throw new ArgumentException("No function defined");

        IFunctionDeterminable function = integralMethodRequest.Function;
        double width = (EndPosition - StartPosition) / NumberOfIterations;
        int percentDivide = 10;

        double totalArea = 0;
        object areaLock = new object();
        object pointLock = new object();

        Parallel.For(0, NumberOfIterations, i =>
        {
            double x0 = StartPosition + i * width;
            double x1 = x0 + width;
            double y0 = function.DetermineFunction(x0);
            double y1 = function.DetermineFunction(x1);

            lock (pointLock)
            {
                XPoints.Add(x1);
                YPoints.Add(y1);
            }
            lock (areaLock)
            {
                totalArea += (y0 + y1) / 2 * width;
            }

            int percent = (i + 1) * 100 / NumberOfIterations;
            if (percent % percentDivide == 0)
                Progress?.Report(percent);
        });

        return totalArea;
    }
}

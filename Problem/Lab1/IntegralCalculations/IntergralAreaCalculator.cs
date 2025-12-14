using Problem.Functions;
using Problem.Lab1.IntegralCalculations;
using System.Threading.Tasks;

internal class IntergralAreaCalculator : FunctionAreaDeterminator
{
    public override double GetIntegral(IntegralMethodRequest integralMethodRequest)
    {
        if (integralMethodRequest?.Function == null)
            throw new ArgumentException("No function defined");

        IFunctionDeterminable function = integralMethodRequest.Function;
        double totalArea = 0;
        double width = (EndPosition - StartPosition) / NumberOfIterations;
        int percentDivide = 10;

        object areaLock = new object();
        object pointLock = new object();

        Parallel.For(0, NumberOfIterations, i =>
        {
            double x = StartPosition + i * width;
            double y = function.DetermineFunction(x);

            lock (pointLock)
            {
                XPoints.Add(x);
                YPoints.Add(y);
            }

            lock (areaLock)
            {
                totalArea += y * width;
            }
            int percent = (i + 1) * 100 / NumberOfIterations;
            if (percent % percentDivide == 0) Progress?.Report(percent);
        });

        return totalArea;
    }
}

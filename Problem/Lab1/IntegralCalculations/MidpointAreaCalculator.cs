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

        object areaLock = new object();
        object pointLock = new object();

        XPoints = new List<double>(NumberOfIterations);
        YPoints = new List<double>(NumberOfIterations);

        Parallel.For(0, NumberOfIterations, i =>
        {
            double x = StartPosition + (i + 0.5) * width;
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
            if (percent % percentDivide == 0)
                Progress?.Report(percent);
        });
        var ordered = XPoints
            .Zip(YPoints, (x, y) => new { x, y })
            .OrderBy(p => p.x)
            .ToList();

        XPoints = ordered.Select(p => p.x).ToList();
        YPoints = ordered.Select(p => p.y).ToList();

        return totalArea;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab1.IntegralCalculations
{
    public class IntegralDeterminer
    {
        public double GetSimpleSquareFunction(double a, double b, double c, double x)
        {
            return a * Math.Pow(x, 2) + b * x + c;
        }

        public double DetermineIntegral(double startX, double endX, int numberOfRectangles, double a, double b, double c)
        {
            double width = (endX - startX) / numberOfRectangles;
            double totalArea = 0;
            double currentX = startX;

            for (int i = 0; i < numberOfRectangles; i++)
            {
                double height = GetSimpleSquareFunction(currentX, a, b, c);
                totalArea += height * width;
                currentX += width;
            }

            return totalArea;
        }
    }
}

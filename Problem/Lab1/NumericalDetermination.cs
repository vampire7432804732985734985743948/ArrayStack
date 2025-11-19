using Problem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab1
{
    public class NumericalDetermination
    {
        private const double START_POSITION = 0;
        private double _endPosition;
        public double EndPosition
        {
            get { return _endPosition; }
            set 
            {
                if (value < START_POSITION) 
                {
                    throw new ArgumentException("Incorrect range");
                }
                else
                {
                    _endPosition = value;
                }
            }
        }

        private int _numberOfIterations;

        public int NumberOfIterations
        {
            get { return _numberOfIterations; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Inappropriate number of itterations");
                }
                else
                {
                    _numberOfIterations = value; 
                }
            }
        }
        public double GetIntegralAreaByTrapezoid(IFuctionDeterminable function)
        {
            double totalArea = 0;
            double width = (_endPosition - START_POSITION) / _numberOfIterations;

            for (int i = 0; i < _numberOfIterations; i++)
            {
                double x0 = START_POSITION + i * width;
                double x1 = x0 + width;

                double area = (function.DetermineFunction(x0) + function.DetermineFunction(x1)) / 2 * width;
                totalArea += area;
            }

            return totalArea;
        }
        public double GetIntegralAreaByMidpoint(IFuctionDeterminable function, EvaluationPoint point)
        {
            double totalArea = 0;
            double width = (_endPosition - START_POSITION) / _numberOfIterations;

            for (int i = 0; i < _numberOfIterations; i++)
            {
                double x = point switch
                {
                    EvaluationPoint.Left => START_POSITION + i * width,
                    EvaluationPoint.Right => START_POSITION + (i + 1) * width,
                    EvaluationPoint.Mid => START_POSITION + (i + 0.5) * width
                };

                totalArea += function.DetermineFunction(x) * width;
            }

            return totalArea;
        }
        public double GetIntergalArea(IFuctionDeterminable fuctionDeterminable)
        {

            double currentPosition = START_POSITION;
            double totalArea = 0;
            double width = (_endPosition - START_POSITION) / _numberOfIterations;

            double currentHeight;
            for (int i = 0; i < _numberOfIterations; i++)
            {
                currentHeight = fuctionDeterminable.DetermineFunction(currentPosition);
                totalArea += currentHeight * width;
                currentPosition += width;
            }
            return totalArea;
        }
    }
}

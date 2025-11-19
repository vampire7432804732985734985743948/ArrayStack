using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Problem.Lab1;
using Problem.Functions;
using Problem.Lab1.IntegralCalculations;

namespace LabTest
{
    public class Lab1Test
    {
        [Fact]
        public void GenerateSequenceTest()
        {
            int numberOfElements = 16;
            int startPosition = 5;
            FibonacciSequence fibonacciSequence = new FibonacciSequence();
            List<int> sequence = fibonacciSequence.GenerateSequenceWithCustomStartingPoint(numberOfElements, startPosition);
            sequence.Should().BeEquivalentTo(new List<int> { 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181});
        }
        [Fact]
        public void CalculateLinearIngegralTest()
        {
            NumericalDetermination numericalDetermination = new NumericalDetermination();
            numericalDetermination.NumberOfIterations = 100;
            numericalDetermination.EndPosition = 2;
            double area = numericalDetermination.GetIntergalArea(new DirectProportionalityFunction());
            area.Should().BeApproximately(1, 1);
        }
        [Fact]
        public void CalculateSinIngegralTest()
        {
            NumericalDetermination numericalDetermination = new NumericalDetermination();
            numericalDetermination.NumberOfIterations = 100;
            numericalDetermination.EndPosition = Math.PI * 2;
            double area = numericalDetermination.GetIntergalArea(new SinFunction());
            area.Should().BeApproximately(0, 0.1);
        }
        [Fact]
        public void CalculateMidPointIngegralTest()
        {
            NumericalDetermination midpointDeterminer = new NumericalDetermination();
            midpointDeterminer.EndPosition = 2;
            midpointDeterminer.NumberOfIterations = 100;
            double mid = midpointDeterminer.GetIntegralAreaByMidpoint(new LinearFuction(), EvaluationPoint.Mid);
            double left = midpointDeterminer.GetIntegralAreaByMidpoint(new LinearFuction(), EvaluationPoint.Left);
            double right = midpointDeterminer.GetIntegralAreaByMidpoint(new LinearFuction(), EvaluationPoint.Right);
            mid.Should().BeApproximately(2, 0.1);
            left.Should().BeApproximately(1.9, 0.1);
            right.Should().BeApproximately(2.1, 0.1);
        }
        [Fact]
        public void CalculateTrapezoidalIngegralTest()
        {
            NumericalDetermination trapezoidalMethod = new NumericalDetermination();
            trapezoidalMethod.EndPosition = 2;
            trapezoidalMethod.NumberOfIterations = 100;
            double result = trapezoidalMethod.GetIntegralAreaByTrapezoid(new DirectProportionalityFunction());
            result.Should().BeApproximately(1, 0.1);
        }

    }
}

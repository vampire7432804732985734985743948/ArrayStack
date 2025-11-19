using Problem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab1.IntegralCalculations.Factory
{
    public class SimpleIntegralFactory : IntegralCalculatorFactory
    {
        public override FunctionAreaDeterminator CreateCalculator()
            => new IntergralAreaCalculator();
    }
}

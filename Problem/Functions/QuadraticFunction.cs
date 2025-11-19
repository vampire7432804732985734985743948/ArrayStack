using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    internal class QuadraticFunction : IFunctionDeterminable
    {
        public string Name => "QuadraticFunction y=2x2+7x";

        public double DetermineFunction(double x) => (2 * Math.Pow(x, 2)) + (7 * x);
    }
}

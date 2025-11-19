using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    internal class ParabolicFunction : IFunctionDeterminable
    {
        public string Name => "ParabolicFunction y=2x^2";

        public double DetermineFunction(double x) => Math.Pow(x, 2) * 2;
    }
}

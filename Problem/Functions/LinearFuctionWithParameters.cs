using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    internal class LinearFuctionWithParameters : IFunctionDeterminable
    {
        public string Name => "Linear fuction y=2x-3";

        public double DetermineFunction(double x) => 2 * x - 3;
    }
}

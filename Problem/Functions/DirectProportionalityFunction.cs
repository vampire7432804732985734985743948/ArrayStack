using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    public class DirectProportionalityFunction : IFunctionDeterminable
    {
        public string Name => "Direct proportionality function";

        public double DetermineFunction(double x) => x / 2;
    }
}

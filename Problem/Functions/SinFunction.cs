using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    public class SinFunction : IFunctionDeterminable
    {
        public string Name => "Sin function";

        public double DetermineFunction(double x) => Math.Sin(x);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    public class LinearFuction : IFunctionDeterminable
    {
        public string Name => "Linear functon y = x";

        public double DetermineFunction(double x) => x;
    }
}

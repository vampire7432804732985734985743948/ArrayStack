using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Functions
{
    public interface IFunctionDeterminable
    {
        string Name { get; }
        public double DetermineFunction(double x);
    }
}

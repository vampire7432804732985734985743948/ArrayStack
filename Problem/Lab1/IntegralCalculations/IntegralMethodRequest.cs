using Problem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab1.IntegralCalculations
{
    public class IntegralMethodRequest
    {
        public IFunctionDeterminable Function { get; private set; }
        public EvaluationPoint? Point { get; set; }

        public IntegralMethodRequest(IFunctionDeterminable function)
        {
            Function = function;
        }
    }
}

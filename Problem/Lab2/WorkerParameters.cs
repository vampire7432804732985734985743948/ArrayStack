using Problem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab2
{
    internal class WorkerParameters
    {
        public double Start { get; set; }
        public double End { get; set; }
        public int Iterations { get; set; }
        public IFunctionDeterminable? Function { get; set; }
        public string RangeName { get; set; } = string.Empty;
    }
}

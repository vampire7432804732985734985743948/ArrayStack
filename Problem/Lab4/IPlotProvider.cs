using Problem.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
namespace Problem.Lab4
{
    internal interface IPlotProvider
    {
        void SavePlot(Plot plot, string fileName, int width, int height);
        void SavePlot(List<Plot> plot, string fileName, int width, int height);
        Plot GeneratePlot(IFunctionDeterminable function);
        List<Plot> GeneratePlot(List<IFunctionDeterminable> function);
    }
}

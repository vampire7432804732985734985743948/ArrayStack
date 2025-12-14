using Problem.Functions;
using ScottPlot;
using ScottPlot.PlotStyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab4
{
    internal class FunctionImageProvider : IPlotProvider
    {
        public List<double> DataX { get; private set; }
        public List<double> DataY { get; private set; }
        public FunctionImageProvider(List<double> dataX, List<double> dataY)
        {
            DataX = dataX;
            DataY = dataY;
        }


        public Plot GeneratePlot(IFunctionDeterminable function)
        {
            if (function == null)
            {
                throw new ArgumentException("Null function");
            }

            ScottPlot.Plot myPlot = new();
            myPlot.Title($"Function flot: {function.Name}");
            myPlot.XLabel("X");
            myPlot.YLabel("Y");
            myPlot.Add.Scatter(DataX, DataY);
            return myPlot;
        }
        public List<Plot> GeneratePlot(List<IFunctionDeterminable> functions)
        {
            if (functions == null)
            {
                throw new ArgumentException("Null function");
            }
            List<Plot> plots = new List<Plot>();
            for (int i = 0; i < functions.Count; i++)
            {
                ScottPlot.Plot myPlot = new();
                myPlot.Title($"Function flot: {functions[i].Name}");
                myPlot.XLabel("X");
                myPlot.YLabel("Y");
                myPlot.Add.Scatter(DataX, DataY);
                plots.Add(myPlot);
            }
            return plots;
        }

        public void SavePlot(Plot plot, string fileName, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Incorrect fileName or filePath");
            }
            plot.SavePng(new StringBuilder(fileName + ".png").ToString(), width, height);
        }
        public void SavePlot(List<Plot> plot, string fileName, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Incorrect fileName or filePath");
            }
            for (int i = 0; i < plot.Count; i++) 
            {
                plot[i].SavePng(new StringBuilder(fileName + i + ".png").ToString(), width, height);
            }
        }
    }
}
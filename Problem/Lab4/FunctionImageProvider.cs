using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab4
{
    internal class FunctionImageProvider
    {
        public double[] DataX { get; private set; }
        public double[] DataY { get; private set; }
        public FunctionImageProvider(double[] dataX, double[] dataY)
        {
            DataX = dataX;
            DataY = dataY;
        }

        public void GenerateAndSavePlot(string filePath, int width, int height)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("IncorrectFileName");
            }

            ScottPlot.Plot myPlot = new();
            myPlot.Add.Scatter(DataX, DataY);
            myPlot.SavePng(filePath, width, height);
        }
    }
}

using Problem.Functions;
using Problem.Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab2
{
    internal class BackgroundWorkerInstantiator
    {
        private (double start, double end, string name)[] ranges =
        {
            (0, 10, "Range 1"),
            (3, 12, "Range 2"),
            (5, 14, "Range 3")
        };
        private BackgroundWorker[] workers = new BackgroundWorker[3];
        public void InitializeWorker()
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };
                workers[i].DoWork += Worker_DoWork;
                workers[i].ProgressChanged += Worker_ProgressChanged;
                workers[i].RunWorkerCompleted += Worker_RunWorkerCompleted;
            }
        }
        public void AssignFunction(IFunctionDeterminable fuction)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i].RunWorkerAsync(new WorkerParameters
                {
                    Start = ranges[i].start,
                    End = ranges[i].end,
                    Iterations = 100000,
                    Function = fuction,
                    RangeName = ranges[i].name
                });
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            WorkerParameters param = (WorkerParameters)e.Argument;

            NumericalDetermination nd = new NumericalDetermination
            {
                StartPosition = param.Start,
                EndPosition = param.End,
                NumberOfIterations = param.Iterations
            };

            int step = param.Iterations / 10; 

            double totalArea = 0;
            double partialResult = 0;

            for (int i = 0; i < 10; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                NumericalDetermination numericalDeterminationPartial = new NumericalDetermination
                {
                    StartPosition = nd.StartPosition + i * step * ((nd.EndPosition - nd.StartPosition) / nd.NumberOfIterations),
                    EndPosition = nd.StartPosition + (i + 1) * step * ((nd.EndPosition - nd.StartPosition) / nd.NumberOfIterations),
                    NumberOfIterations = step
                };

                partialResult = numericalDeterminationPartial.GetIntegralAreaByTrapezoid(param.Function);
                totalArea += partialResult;

                int progress = (i + 1) * 10;
                worker.ReportProgress(progress, param.RangeName);
            }

            e.Result = new { param.RangeName, Result = totalArea };
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.UserState}: {e.ProgressPercentage}%");
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                var result = (dynamic)e.Result;
                Console.WriteLine($"{result.RangeName} result = {result.Result:F6}");
            }
        }

        public bool AllWorkersCompleted()
        {
            foreach (var w in workers)
            {
                if (w.IsBusy)
                    return false;
            }
            return true;
        }

    }
}

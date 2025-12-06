using Problem.Functions;
using Problem.Lab1;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Problem.Lab2
{
    internal class BackgroundWorkerInstantiator
    {
        private readonly List<(double start, double end, string name)> _ranges;
        private readonly List<BackgroundWorker> _workers = new();

        public BackgroundWorkerInstantiator(IEnumerable<(double start, double end, string name)> ranges)
        {
            _ranges = ranges.ToList();
        }

        public void InitializeWorkers()
        {
            foreach (var _ in _ranges)
            {
                var worker = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = false
                };

                worker.DoWork += Worker_DoWork;
                worker.ProgressChanged += Worker_ProgressChanged;
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                _workers.Add(worker);
            }
        }

        public void Run(IFunctionDeterminable function, int iterations)
        {
            for (int i = 0; i < _ranges.Count; i++)
            {
                var (start, end, name) = _ranges[i];

                _workers[i].RunWorkerAsync(new WorkerParameters
                {
                    Start = start,
                    End = end,
                    Iterations = iterations,
                    Function = function,
                    RangeName = name
                });
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var p = (WorkerParameters)e.Argument;
            var worker = (BackgroundWorker)sender;

            const int stepCount = 10;
            int stepIterations = p.Iterations / stepCount;
            double segment = (p.End - p.Start) / stepCount;

            double total = 0;

            for (int i = 0; i < stepCount; i++)
            {
                double s = p.Start + i * segment;
                double ep = s + segment;

                var calc = new NumericalDetermination(s, ep, stepIterations)
                {
                    StartPosition = s,
                    EndPosition = ep,
                    NumberOfIterations = stepIterations
                };

                total += calc.GetIntegralAreaByTrapezoid(p.Function);
                worker.ReportProgress((i + 1) * 10, p.RangeName);
            }

            e.Result = new { p.RangeName, Result = total };
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.UserState}: {e.ProgressPercentage}%");
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is null) return;

            var r = (dynamic)e.Result;
            Console.WriteLine($"{r.RangeName} result = {r.Result:F6}");
        }

        public bool AllWorkersCompleted() => _workers.All(w => !w.IsBusy);
    }
}

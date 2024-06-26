using Problem.Stack;
using Problem.graph;
using Problem.Dictionary;
using Problem.List;
using Problem;
using System.Numerics;
using System.Net.Http.Headers;

Problem.List.Vector<int> values = new Problem.List.Vector<int>() {2,4,7,9,5,1};

values.Sort();
values.ShowData();

Problem.List.Vector<int> values1 = new Problem.List.Vector<int>() { 2, 4, 7, 9, 53, 131 };
Console.WriteLine("______________");
values = values.Union(values1);

values.ShowData();
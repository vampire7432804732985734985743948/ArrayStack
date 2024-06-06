using Problem.Stack;
using Problem.graph;
using Problem.Dictionary;
using Problem.List;
using Problem;
using System.Numerics;

Problem.List.Vector<string> values = new Problem.List.Vector<string>();

values.Add("First");
values.Add("Second");
values.Add("Third");
values.Add("Fourth");
values.Add("Fifth");
values.Insert("Sixth", 2);

foreach (var value in values)
{
    Console.WriteLine(value);
}

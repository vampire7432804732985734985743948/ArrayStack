using Problem.Stack;
using Problem.graph;
using Problem.Dictionary;
using Problem.List;
using Problem;
using System.Numerics;

Problem.List.Vector<int> ints = new Problem.List.Vector<int>();

ints.Add(1);
ints.Add(2);
ints.Add(3);
ints.Add(4);
ints.Add(5);
ints.Add(6);
ints.Add(7);
ints.Add(9);
ints.Add(8);

Problem.List.Vector<int> ints2 = new Problem.List.Vector<int>();

ints2.Add(1);
ints2.Add(2);
ints2.Add(3);
ints2.Add(33);
ints2.Add(4);
ints2.Add(5);
ints2.Add(6);
ints2.Add(9);
ints2.Add(8);


Problem.List.Vector<int> ints3 = new Problem.List.Vector<int>();
ints3 = ints.Difference(ints2);

foreach (var i in ints3)
{
    Console.WriteLine(i);
}

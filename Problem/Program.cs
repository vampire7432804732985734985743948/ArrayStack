using Problem.Stack;
using Problem.graph;
using Problem.Dictionary;
using Problem.List;
using Problem;
using System.Numerics;

Problem.Dictionary.Dictionary<int, string> dictionary = new Problem.Dictionary.Dictionary<int, string>();


dictionary.Add(1, "1");
dictionary.Add(3, "3");
dictionary.Add(2, "2");
dictionary.Add(5, "5");
dictionary.Add(6, "6");
dictionary.Add(4, "4");

dictionary.OrderByAscending();
dictionary.Show();
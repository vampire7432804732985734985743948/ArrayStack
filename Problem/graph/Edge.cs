using System;
using System.Text;

namespace Problem.graph
{
    internal class Edge
    {
        public Vertex? From { get; private set; }
        public Vertex? To { get; private set; }
        public int Weight { get; private set; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{From} {To}";
        }
    }
}

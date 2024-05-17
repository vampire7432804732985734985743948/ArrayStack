using System;

namespace Problem.graph
{
    internal class Vertex
    {
        public int Number { get; private set; }

        public Vertex(int number = 0)
        {
            Number = number;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}

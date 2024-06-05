using System;
using System.Collections.Generic;

namespace Problem.graph
{
    internal class Graph
    {
        private List<Vertex> _vertices = new List<Vertex>();
        private List<Edge> _edges = new List<Edge>();
        public int VerticesCount { get; private set; }
        public int EdgesCount { get; private set; }
        public bool IsDirected { get; private set; }

        public Graph(bool isDirected = false)
        {
            IsDirected = isDirected;
        }

        public void AddVertex(Vertex vertex)
        {
            if (!_vertices.Contains(vertex))
            {
                _vertices.Add(vertex);
                VerticesCount++;
            }
            else
            {
                Console.WriteLine("All the objects are to be unique");
            }
        }

        public void CreateEdge(Vertex from, Vertex to, int weight = 1)
        {
            _edges.Add(new Edge(from, to, weight));
            if (!IsDirected)
            {
                _edges.Add(new Edge(to, from, weight));
            }
            EdgesCount++;
        }

        public int[,] GenerateMatrix()
        {
            var matrix = new int[_vertices.Count, _vertices.Count];

            foreach (var edge in _edges)
            {
                var row = edge.From.Number - 1;
                var column = edge.To.Number - 1;
                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }

        private List<Vertex> GenerateList(Vertex vertex)
        {
            var adjacencyList = new List<Vertex>();
            if (_edges.Count > 0)
            {
                foreach (var edge in _edges)
                {
                    if (edge.From == vertex && vertex != null)
                    {
                        adjacencyList.Add(edge.To);
                    }
                }
            }
            else
            {
                Console.WriteLine("The graph isn't connected");
            }
            return adjacencyList;
        }

        public void GetList()
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                Console.Write($"{_vertices[i].Number}: ");
                foreach (var item in GenerateList(_vertices[i]))
                {
                    Console.Write($"{item.Number} ");
                }
                Console.WriteLine();
            }
        }
        public void GetMatrix()
        {
            int[,] matrix = GenerateMatrix();
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < _vertices.Count; i++)
            {
                for (int j = 0; j < _vertices.Count; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
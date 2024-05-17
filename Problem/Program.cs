using Problem.Stack;
using Problem.graph;
using Problem;
using Problem.Set;

Graph graph = new Graph();

Vertex vertex0 = new Vertex(0);
Vertex vertex1 = new Vertex(1);
Vertex vertex2 = new Vertex(2);
Vertex vertex3 = new Vertex(3);
Vertex vertex4 = new Vertex(4);

graph.AddVertex(vertex0);
graph.AddVertex(vertex1);
graph.AddVertex(vertex2);
graph.AddVertex(vertex3);

graph.CreateEdge(vertex0, vertex1);
graph.CreateEdge(vertex1, vertex2);
graph.CreateEdge(vertex2, vertex3);
graph.CreateEdge(vertex3, vertex1);

var matrix = graph.GenerateMatrix();

for (int i = 0; i < graph.VerticesCount; i++)
{
	for (int j = 0; j < graph.EdgesCount; j++)
	{
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}

graph.GetList();
using Problem.Stack;
using Problem.graph;
using Problem.Dictionary;
using Problem.List;
using Problem;
using System.Numerics;

Problem.graph.Graph graph = new Graph();

Vertex vertex1 = new Vertex(1);
Vertex vertex2 = new Vertex(2);
Vertex vertex3 = new Vertex(3);
Vertex vertex4 = new Vertex(4);
Vertex vertex5 = new Vertex(5);
Vertex vertex6 = new Vertex(6);


graph.AddVertex(vertex1);
graph.AddVertex(vertex2);
graph.AddVertex(vertex3);
graph.AddVertex(vertex4);
graph.AddVertex(vertex5);
graph.AddVertex(vertex6);

graph.CreateEdge(vertex1, vertex2);
graph.CreateEdge(vertex1, vertex3);
graph.CreateEdge(vertex2, vertex4);
graph.CreateEdge(vertex2, vertex5);
graph.CreateEdge(vertex4, vertex6);

graph.GetMatrix();
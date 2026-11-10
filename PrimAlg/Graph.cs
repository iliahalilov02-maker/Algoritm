using System.Collections.Generic;

namespace PrimAlgorithm;

/// Неориентированный взвешенный граф на списке смежности.
public class Graph
{
    public int VertexCount { get; }
    public List<List<Edge>> Adjacency { get; }

    public Graph(int vertexCount)
    {
        VertexCount = vertexCount;
        Adjacency = new List<List<Edge>>(vertexCount);
        for (int i = 0; i < vertexCount; i++)
            Adjacency.Add(new List<Edge>());
    }

    /// Добавляет неориентированное ребро (u — v).
    public void AddEdge(int u, int v, int weight)
    {
        Adjacency[u].Add(new Edge(v, weight));
        Adjacency[v].Add(new Edge(u, weight));
    }
}
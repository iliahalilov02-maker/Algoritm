using System.Collections.Generic;

namespace PrimAlgorithm;

/// Реализация алгоритма Прима поиска минимального остовного дерева.

public static class Prim
{
    public record MstEdge(int From, int To, int Weight);

    public class MstResult
    {
        public List<MstEdge> Edges { get; } = new();
        public int TotalWeight { get; set; }
    }

    
    public static MstResult FindMST(Graph graph, int start = 0)
    {
        int n = graph.VertexCount;
        var inMst = new bool[n];
        var result = new MstResult();

        // Min-heap по весу ребра
        var pq = new PriorityQueue<MstEdge, int>();

        inMst[start] = true;
        foreach (var edge in graph.Adjacency[start])
            pq.Enqueue(new MstEdge(start, edge.To, edge.Weight), edge.Weight);

        while (pq.Count > 0 && result.Edges.Count < n - 1)
        {
            var current = pq.Dequeue();

            if (inMst[current.To])
                continue;

            inMst[current.To] = true;
            result.Edges.Add(current);
            result.TotalWeight += current.Weight;

            foreach (var edge in graph.Adjacency[current.To])
            {
                if (!inMst[edge.To])
                    pq.Enqueue(new MstEdge(current.To, edge.To, edge.Weight), edge.Weight);
            }
        }

        return result;
    }
}
using System;
using PrimAlgorithm;

class Program
{
    static void Main()
    {
        var graph = new Graph(5);

        graph.AddEdge(0, 1, 2);
        graph.AddEdge(0, 3, 6);
        graph.AddEdge(1, 2, 3);
        graph.AddEdge(1, 3, 8);
        graph.AddEdge(1, 4, 5);
        graph.AddEdge(2, 4, 7);
        graph.AddEdge(3, 4, 9);

        var mst = Prim.FindMST(graph);

        Console.WriteLine("Рёбра минимального остовного дерева:");
        foreach (var edge in mst.Edges)
            Console.WriteLine($"  {edge.From} — {edge.To} (вес {edge.Weight})");

        Console.WriteLine($"Суммарный вес: {mst.TotalWeight}");
    }
}
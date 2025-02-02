/* CSE 381 - Graph
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Do not modify this file.  You will use this in your code.
*/

namespace AlgorithmLib;

public class Edge
{
    // Each edge is defined by the vertex that is goes to (DestId)
    // and the weight of the edge (Weight).
    public int DestId { get; set; }
    public int Weight { get; set; }
}

public class Graph
{
    // Implemented using an adjacency table.  The graph
    // is a list where the index represents the vertex ID.
    // The value in the list represents all the edges that
    // are connected to the vertex.  
    private readonly List<List<Edge>> _graph; 
    private readonly List<string> _labels;
    
    public static int INF = Int32.MaxValue;

    /* Initialize the graph based on the size */
    public Graph(int size)
    {
        _graph = Enumerable.Range(0, size).Select(_ => new List<Edge>()).ToList();
        _labels = Enumerable.Range(0, size).Select(_ => "").ToList();
    }

    /* Add a directed edge with a default weight of 0 */
    public void AddDirectedEdge(int srcId, int destId, int weight=0)
    {
        var edge = new Edge { DestId = destId, Weight = weight };
        _graph[srcId].Add(edge);
    }

    /* Add an undirected edge with a default weight of 0. */
    public void AddUndirectedEdge(int srcId, int destId, int weight=0)
    {
        // Add 2 directed edges going in opposite directions with the same weight
        AddDirectedEdge(srcId, destId, weight);
        AddDirectedEdge(destId, srcId, weight);
    }

    /* Get a list of edges connected to vertex id */
    public List<Edge> Edges(int id)
    {
        return _graph[id];
    }

    /* Get the number of vertices in the graph */
    public int Size()
    {
        return _graph.Count;
    }
    
    /* Associate a name to each vertex for readability */
    public void SetLabel(int id, string label)
    {
        _labels[id] = label;
    }

    /* Get the name associated with a vertex id */
    public string GetLabel(int id)
    {
        return _labels[id];
    }
}
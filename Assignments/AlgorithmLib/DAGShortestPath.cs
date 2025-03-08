/* CSE 381 - DAG Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Sort and Search functions per the instructions
*  in the comments.  Run all tests in DAGShortestPathTest.cs to verify your code.
*/

namespace AlgorithmLib;


    // The reason I chose to go with this method is becuase my origional method that I was using, the In_degree method, kept returning things in the wrong order, ie it would put 5 first rather than the 7, and I got tired of it and tried the method from w3 schools which worked.
public static class DAGShortestPath
{
    /* Topologically sort all vertices in a graph and return the sorted
     * list of vertex ID's.  Use a Stack object (available in C#).
     *
     *  Inputs:
     *     g - Graph
     *  Outputs:
     *     Return a sorted list of vertex ID's
     */
    public static List<int> Sort(Graph g) {

        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[g.Size()];

        for (int i = 0; i < g.Size(); i++) {
            if (!visited[i]) {
                TopologicalSortUtil(g, i, visited, stack);
            }
        }

        return stack.ToList();
    }


    // based on the design from https://www.geeksforgeeks.org/topological-sorting/, it seemed like a found solution.
    // I was able to understand the material from this website, although i dont really have a better way to implement it.
    private static void TopologicalSortUtil(Graph g, int v, bool[] visited, Stack<int> stack) {
        visited[v] = true;

        foreach (var edge in g.Edges(v)) {
            if (!visited[edge.DestId]) {
                TopologicalSortUtil(g, edge.DestId, visited, stack);
            }
        }

        stack.Push(v);
    }

    /* Find the shortest path from a starting vertex to all
     * vertices in a DAG.  This function will need to
     * call the Sort function to obtain the topologically
     * sorted list of vertices from the graph.
     *
     *  Inputs:
     *     g - Directed Acyclic Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list) 
     *     NOTE: The above two output lists should contain Graph.INF as needed
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex) {

        List<int> sortedVertexes = Sort(g);

        List<int> distances = new List<int>(new int[g.Size()]);
        List<int> predecessors = new List<int>(new int[g.Size()]);

        for (int i = 0; i < g.Size(); i++) {

            // i had used various sources on the internet and this for whatever reason appears to be the desired solution,
            //

            distances[i] = Graph.INF;
            predecessors[i] = Graph.INF;
        }

        distances[startVertex] = 0;


        // an iterative check, I just chose to go through everything,
        // i know this is a O(n^2) but I didn't know a better way to accomplish this.

        foreach (int vertex in sortedVertexes) {

            if (distances[vertex] == Graph.INF) { continue; }

            foreach (var edge in g.Edges(vertex)) {

                int newDistance = distances[vertex] + edge.Weight;

                if(newDistance < distances[edge.DestId])
                {
                    distances[edge.DestId] = newDistance;
                    predecessors[edge.DestId] = vertex;
                }
            }
        }
        return (distances, predecessors);
    }
    
}
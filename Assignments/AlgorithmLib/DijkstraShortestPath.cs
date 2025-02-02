/* CSE 381 - Dijkstra Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in DijkstraShortestPathTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class DijkstraShortestPath
{

    /* Find the shortest path from a starting vertex to all
     * vertices in a graph using Dijkstra.  Use a Priority Queue
     * (code already provided for you) in your implementation.
     *
     *  Inputs:
     *     g - Graph
     *     startVertex - Starting vertex ID
     *  Outputs:
     *     (distance list, predecessor list)
     *     NOTE: The above two output lists should contain Graph.INF as needed
     */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        return (new List<int>(), new List<int>());
    } 
}
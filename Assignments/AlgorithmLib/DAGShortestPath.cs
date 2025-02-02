/* CSE 381 - DAG Shortest Path
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Sort and Search functions per the instructions
*  in the comments.  Run all tests in DAGShortestPathTest.cs to verify your code.
*/

namespace AlgorithmLib;

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
    public static List<int> Sort(Graph g)
    {
        return new List<int>();
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
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        return (new List<int>(), new List<int>());
    } 
    
}
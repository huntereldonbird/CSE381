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
        int size = g.Size();
        List<int> distance = Enumerable.Repeat(Graph.INF, size).ToList();
        List<int> predecessor = Enumerable.Repeat(-1, size).ToList();
        List<bool> visited = new List<bool>(new bool[size]);

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        pq.Enqueue(startVertex, 0);
        distance[startVertex] = 0;
        predecessor[startVertex] = Graph.INF;


        while (pq.Count > 0) {

            int current = pq.Dequeue();

            if (visited[current]) {
                continue;
            }
            visited[current] = true;

            foreach (var edge in g.Edges(current)) {

                int new_distance = distance[current] + edge.Weight;

                if (visited[edge.DestId]) {
                    continue;
                }


                if (new_distance < distance[edge.DestId]) {

                    distance[edge.DestId] = new_distance;
                    predecessor[edge.DestId] = current;

                    pq.Enqueue(edge.DestId, new_distance);

                }
            }
        }

        return (distance, predecessor);
    }

}
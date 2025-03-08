/* CSE 381 - Bellman Ford
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the ShortestPath function per the instructions
*  in the comments.  Run all tests in BellmanFordTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class BellmanFordShortestPath
{
    /* Find the Shortest Path in a graph using the Bellman Ford Algorithm
    *  with the ability to detect a negative cycle.
    *
    *  Inputs:
    *     g - The Graph (using the Graph class provided)
    *     startVertex - The vertex ID to calculate shortest path from
    *  Outputs:
    *     (Distance List, Predecessor List)
    *     NOTE: The above two output lists should contain Graph.INF as needed
    *
    *  Note: If a negative cycle exists, then the function must return
    *  a tuple of two empty lists. 
    */
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex) {

        int[] distances = new int[g.Size()];
        int[] previous = new int[g.Size()];
        for (int i = 0; i < g.Size(); i++) {

            distances[i] = Graph.INF;
            previous[i] = Graph.INF;

        }

        distances[startVertex] = 0;

        for (int i = 0; i < g.Size(); i++) {
            for (int j = 0; j < g.Size(); j++) {


                if (distances[j] == Graph.INF && j != startVertex) {
                    continue;
                }

                foreach (var edge in g.Edges(j)) {

                    int v = edge.DestId;
                    int weight = edge.Weight;

                    if (distances[j] != Graph.INF && distances[j] + weight < distances[v]) {

                        distances[v] = distances[j] + weight;
                        previous[v] = j;

                    }

                }
            }

        }


        // the internet told me to add this

        bool negative = false;

        for (int i = 0; i < g.Size(); i++) {

            if (distances[i] == Graph.INF) {
                continue;
            }

            foreach (var edge in g.Edges(i)) {

                int v = edge.DestId;
                int weight = edge.Weight;

                if (distances[i] != Graph.INF && distances[i] + weight < distances[v]) {
                    negative = true;
                    break;
                }
            }

            if (negative) {
                return (new List<int>(), new List<int>());
            }

        }


        return (distances.ToList(), previous.ToList());
    } 
}
# CSE 381 REPL 6B Solution
# Dijkstra Shortest Path - With Priority Queue

from graph import Graph
from graph import INF
from queue import PriorityQueue

def shortest_path(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    queue = PriorityQueue()
    for index in range(graph.size()):
        queue.enqueue(index, distance[index])

    while queue.size() > 0:

        vertex = queue.dequeue()
        
        for edge in graph.edges(vertex):
            if distance[vertex] + edge.weight < distance[edge.destId]:
                distance[edge.destId] = distance[vertex] + edge.weight
                pred[edge.destId] = vertex;
                queue.decrease_priority(edge.destId, distance[edge.destId])

    return (distance,pred)    

g = Graph(5)
g.set_label(0, "A");
g.set_label(1, "B");
g.set_label(2, "C");
g.set_label(3, "D");
g.set_label(4, "E");
g.add_directed_edge(0, 1, 4);
g.add_directed_edge(0, 3, 7);
g.add_directed_edge(1, 0, 3);
g.add_directed_edge(1, 2, 6);
g.add_directed_edge(2, 1, 6);
g.add_directed_edge(2, 4, 3);
g.add_directed_edge(3, 2, 1);
g.add_directed_edge(4, 0, 4);
shortest, pred = shortest_path(g, 0)
print(shortest)
print(pred)
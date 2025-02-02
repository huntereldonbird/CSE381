# CSE 381 REPL 7A Solution
# Bellman-Ford Shortest Path

from graph import Graph
from graph import INF

def shortest_path(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    for i in range(graph.size()-1): 
        changesMade = False
        for node in range(0,graph.size()):
            for edge in graph.edges(node):
                if distance[node] + edge.weight < distance[edge.destId]:
                    changesMade = True
                    distance[edge.destId] = distance[node] + edge.weight
                    pred[edge.destId] = node
        if not changesMade:
            print(f"Exiting at i={i}")
            break
    return (distance,pred)


g = Graph(6);
g.set_label(0, "S");
g.set_label(1, "A");
g.set_label(2, "B");
g.set_label(3, "C");
g.set_label(4, "D");
g.set_label(5, "E");
g.add_directed_edge(0, 5, 8);
g.add_directed_edge(0, 1, 10);
g.add_directed_edge(1, 3, 2);
g.add_directed_edge(2, 1, 1);
g.add_directed_edge(3, 2, -2);
g.add_directed_edge(4, 1, -4);
g.add_directed_edge(4, 3, -1);
g.add_directed_edge(5, 4, 1);
(distance, pred) =shortest_path(g, 0);
for index in range(len(distance)):
    print(f"{index} ({g.get_label(index)}) : {distance[index]} Pred: {pred[index]}")


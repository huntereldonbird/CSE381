# CSE 381 REPL 7B Solution
# Negative Weight Cycles

from graph import Graph
from graph import INF
import math

def shortest_path(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    for i in range(graph.size()):  # n times (last n is to check negative cycles)
        changesMade = False
        for vertex in range(0,graph.size()):
            for edge in graph.edges(vertex):
                if distance[vertex] + edge.weight < distance[edge.destId]:
                    if i == graph.size()-1:
                        cycle = find_negative_weight_cycle(graph, pred, edge.destId)
                        print(f"Negative Cycle: {cycle}")
                        return ([],[])
                    changesMade = True
                    distance[edge.destId] = distance[vertex] + edge.weight
                    pred[edge.destId] = vertex
        if not changesMade:
            break
    print("No Negative Cycle found!")
    return (distance,pred)

def find_negative_weight_cycle(graph, pred, vertex):
    # vertex is either on the cycle or can be reached from the cycle
    visited = [False]*graph.size()
    curr = vertex
    # follow the predecessors for vertex until we complete a cycle
    while visited[curr] == False:
        visited[curr] = True
        x = pred[curr]
    # Curr is a vertex on a negative-weight cycle.  
    start = curr
    cycle = [curr]
    curr = pred[curr]
    # Follow predecessors to capture the full cycle
    while curr != start:
        cycle.insert(0,curr)
        curr = pred[curr]
    return cycle
    
    

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

print("------------")

g = Graph(6);
g.set_label(0, "T");
g.set_label(1, "A");
g.set_label(2, "B");
g.set_label(3, "C");
g.set_label(4, "D");
g.set_label(5, "E");
g.add_directed_edge(0, 5, 8);
g.add_directed_edge(0, 1, 10);
g.add_directed_edge(1, 3, 2);
g.add_directed_edge(2, 1, 1);
g.add_directed_edge(3, 2, -4); # Changed C->B from -2 to -4
g.add_directed_edge(4, 1, -4);
g.add_directed_edge(4, 3, -1);
g.add_directed_edge(5, 4, 1);
(distance, pred) =shortest_path(g, 0);
for index in range(len(distance)):
    print(f"{index} ({g.get_label(index)}) : {distance[index]} Pred: {pred[index]}")



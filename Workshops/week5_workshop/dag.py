# CSE 381 Workshop
# Pert Chart

from graph import Graph
from graph import INF

def sort(graph):
    in_degree = [0] * graph.size()
    linear_order = []

    for vertex in range(graph.size()):
        for edge in graph.edges(vertex):
            in_degree[edge.destId] += 1
    next = []
    for vertex in range(graph.size()):
        if in_degree[vertex] == 0:
            next.append(vertex)

    while len(next) > 0:
        vertex = next.pop()
        linear_order.append(vertex)
        for edge in graph.edges(vertex):
            in_degree[edge.destId] -= 1
            if in_degree[edge.destId] == 0:
                next.append(edge.destId)

    return linear_order
    
def shortest_path(graph, start_vertex):
    sorted = sort(graph)
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()

    distance[start_vertex] = 0

    for vertex in sorted:
        if distance[vertex] != INF:
            for edge in graph.edges(vertex):
                if distance[vertex] + edge.weight < distance[edge.destId]:
                    distance[edge.destId] = distance[vertex] + edge.weight
                    pred[edge.destId] = vertex

    return (distance, pred)


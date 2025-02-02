# CSE 381 Workshop 7
# Sparse vs Dense Graphs

from graph import Graph
from graph import INF
from queue import PriorityQueue
import time
import random

# Shortest path using a list - O(V^2 + E)
def shortest_path_array(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    unvisited = set(range(graph.size()))
    count = 0

    while len(unvisited) > 0:
        vertex = min(unvisited, key=lambda v : distance[v])
        unvisited.remove(vertex)
        for edge in graph.edges(vertex):
            if distance[vertex] + edge.weight < distance[edge.destId]:
                distance[edge.destId] = distance[vertex] + edge.weight
                pred[edge.destId] = vertex
                count += 1
    return (distance, pred, count)

# Shortest Path using a Priority Queue / Heap - O(V log V + E log V)
def shortest_path_priqueue(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    queue = PriorityQueue()
    for index in range(graph.size()):
        queue.enqueue(index, distance[index])
    count = 0

    while queue.size() > 0:

        vertex = queue.dequeue()
        
        for edge in graph.edges(vertex):
            if distance[vertex] + edge.weight < distance[edge.destId]:
                distance[edge.destId] = distance[vertex] + edge.weight
                pred[edge.destId] = vertex;
                queue.decrease_priority(edge.destId, distance[edge.destId])
                count += 1

    return (distance,pred,count)

v = 5000

print("Creating Dense")
dense = Graph(v)
for i in range(v):
    for j in range(v):
        if i != j:
            dense.add_directed_edge(i, j, random.choice([-1,1,2]))
print(f"V = {dense.size()} E = {dense.total_edges()}")

print("Creating Sparse")
sparse = Graph(v)
for i in range(v):
    for j in range(4):
        j = random.choice(list(range(v)))
        sparse.add_directed_edge(i, j, random.choice([-1,1,2]))
print(f"V = {sparse.size()} E = {sparse.total_edges()}")

print("Running Shortest Path")
start = time.perf_counter()
dist, pred, count = shortest_path_array(sparse, 0)
stop = time.perf_counter()
print(f"sparse with array : seconds = {stop-start} edges relaxed = {count}")

start = time.perf_counter()
dist, pred, count = shortest_path_array(dense, 0)
stop = time.perf_counter()
print(f"dense with array : seconds = {stop-start} edges relaxed = {count}")

start = time.perf_counter()
dist, pred, count = shortest_path_priqueue(sparse, 0)
stop = time.perf_counter()
print(f"sparse with pri queue : seconds = {stop-start} edges relaxed = {count}")

start = time.perf_counter()
dist, pred, count = shortest_path_priqueue(dense, 0)
stop = time.perf_counter()
print(f"dense with pri queue : seconds = {stop-start} edges relaxed = {count}")



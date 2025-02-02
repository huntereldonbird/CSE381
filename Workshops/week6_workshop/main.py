# CSE 381 Workshop 6
# CA Roads

# Source: https://users.cs.utah.edu/~lifeifei/SpatialDataset.htm
# Note that distance is not miles but distance measured on the map

from graph import Graph
from graph import INF
from queue import PriorityQueue
import time

CONVERSION_UNITS_TO_MILES = 65  # Approximation with units Miles / Drawing Units

# Shortest path using a list - O(V^2 + E)
def shortest_path1(graph, start_vertex):
    distance = [INF] * graph.size()
    pred = [INF] * graph.size()
    distance[start_vertex] = 0

    unvisited = set(range(graph.size()))

    while len(unvisited) > 0:
        vertex = min(unvisited, key=lambda v : distance[v])
        unvisited.remove(vertex)
        for edge in graph.edges(vertex):
            if distance[vertex] + edge.weight < distance[edge.destId]:
                distance[edge.destId] = distance[vertex] + edge.weight
                pred[edge.destId] = vertex
    return (distance, pred)

# Shortest Path using a Priority Queue / Heap - O(V log V + E log V)
def shortest_path2(graph, start_vertex):
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

print("Generating Graph")

vertices = []
with open("Workshops/week6_workshop/ca_roads_vertices.txt") as fd:
    for line in fd:
        vertices.append(line.strip().split(" "))

g = Graph(len(vertices))

with open("Workshops/week6_workshop/ca_roads_edges.txt") as fd:
    for line in fd:
        fields = line.strip().split(" ")
        src_id = int(fields[1])
        dst_id = int(fields[2])
        distance = float(fields[3]) * CONVERSION_UNITS_TO_MILES

print(f"Graph Generated: V={g.size()} E={g.total_edges()}")

# Path from max distance to starting point (Part 4)
# with open("Workshops/week6_workshop/route.csv","w") as fd:
#     fd.write("Latitude,Longitude\n")
#     start = 0
#     curr = max_index
#     while True:
#         fd.write(f"{vertices[curr][2]},{vertices[curr][1]}\n")
#         if curr == start:
#             break
#         curr = pred[curr]
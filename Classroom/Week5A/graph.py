class Edge:
    def __init__(self, destId, weight):
        self.destId = destId
        self.weight = weight

class Graph:
    def __init__(self, size):
        self._graph = [ [] for _ in range(size)]
        self._labels = [ "" for _ in range(size)]

    def set_label(self, id, label):
        self._labels[id] = label

    def add_directed_edge(self, srcId, destId, weight=0):
        edge = Edge(destId, weight)
        self._graph[srcId].append(edge)

    def add_undirected_edge(self, srcId, destId, weight=0):
        self.add_directed_edge(srcId, destId, weight)
        self.add_directed_edge(destId, srcId, weight)

    def edges(self, id):
        return self._graph[id]

    def size(self):
        return len(self._graph)

    def get_label(self, id):
        return self._labels[id]

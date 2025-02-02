def dag_topological_sort(graph):
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
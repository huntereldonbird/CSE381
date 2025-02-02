# CSE 381 REPL5A
# DAG Topological Sort

from graph import Graph

def dag_topological_sort(graph):
    pass
    
g = Graph(9)
g.set_label(0,"A")
g.set_label(1,"B")
g.set_label(2,"C")
g.set_label(3,"D")
g.set_label(4,"E")
g.set_label(5,"F")
g.set_label(6,"G")
g.set_label(7,"H")
g.set_label(8,"I")
g.add_directed_edge(0,3)
g.add_directed_edge(1,3)
g.add_directed_edge(2,5)
g.add_directed_edge(3,6)
g.add_directed_edge(5,6)
g.add_directed_edge(4,8)
g.add_directed_edge(6,8)
g.add_directed_edge(7,8)
order = dag_topological_sort(g)
for vertex in order:
    print(g.get_label(vertex))


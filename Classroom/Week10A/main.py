# CSE 381 REPL 10A 
# Huffman Trees

from queue import PriorityQueue

class Node:

    def __init__(self):
        self.letter = ''
        self.count = 0
        self.left = None
        self.right = None

    def __str__(self):
        return f"({self.letter},{self.count}) "

def print_tree(node, indent=''):
    if node is not None:
        print_tree(node.right, indent+'   ')
        print(indent,node)
        print_tree(node.left, indent+'   ')
        
def profile(text):
    pass

def build_tree(profile):
    pass

# a-2, b-4, c-3, d-5, e-6, f-4, g-8 Total=32
text = "aabbbbcccdddddeeeeeeffffgggggggg";
profile = profile(text);
print(f"Profile: {profile}")
tree = build_tree(profile);
print_tree(tree)

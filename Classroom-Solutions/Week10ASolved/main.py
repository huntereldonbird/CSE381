# CSE 381 REPL 10A Solution
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
    profile = {}
    for letter in text:
        if letter in profile:
            profile[letter] += 1
        else:
            profile[letter] = 1
    return profile

def build_tree(profile):
    q = PriorityQueue()
    for letter in profile.keys():
        node = Node()
        node.letter = letter
        node.count = profile[letter]
        q.enqueue(node, node.count)

    while q.size() > 1:
        x = q.dequeue()
        y = q.dequeue()
        z = Node()
        z.count = x.count + y.count
        z.left = x
        z.right = y
        q.enqueue(z, z.count)

    return q.dequeue()

# a-2, b-4, c-3, d-5, e-6, f-4, g-8 Total=32
text = "aabbbbcccdddddeeeeeeffffgggggggg";
profile = profile(text);
print(f"Profile: {profile}")
tree = build_tree(profile);
print_tree(tree)


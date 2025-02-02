# CSE 381 REPL 10B 
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
        print(indent, node)
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

def create_encoding_map(root):
    map = {}
    _create_encoding_map(root, "", map)
    return map

def _create_encoding_map(node, code, map):
    if node is None:
        # Empty tree
        return 
    if node.left is None and node.right is None:
        if len(code) == 0:
            # Special Case with only one node in tree
            map[node.letter] = "1" 
        else:
            # A leaf
            map[node.letter] = code 
    else:
        pass

    
def encode(text, map):
    pass

def decode(text, tree):
    pass


text = "aabbbbcccdddddeeeeeeffffgggggggg";
#text = "the rain in spain stays mainly in the plain";
print(f"{text} ({len(text)*8} bits)");
profile = profile(text);
tree = build_tree(profile);
print_tree(tree)
encoding_map = create_encoding_map(tree);
print(f"Encoding Map: {encoding_map}")
encoded = encode(text, encoding_map);
print(f"Encoded: {encoded} ({len(encoded)} bits)");
decoded = decode(encoded, tree);
print(f"Decoded: {decoded} ({len(decoded)*8} bits)");
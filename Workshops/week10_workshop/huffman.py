# CSE 381 Workshop 10
# Do not change the code in this file

from queue import PriorityQueue

class Node:

    def __init__(self):
        self.letter = ''
        self.count = 0
        self.left = None
        self.right = None

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
        return # Empty tree
    if node.left is None and node.right is None:
        if len(code) == 0:
            map[node.letter] = "1" # Special Case with only one node in tree
        else:
            map[node.letter] = code # A leaf
    else:
        _create_encoding_map(node.left, code + "0", map)
        _create_encoding_map(node.right, code + "1", map)

    
def encode(text, map):
    result = ""
    for letter in text:
        result += map[letter]
    return result

def decode(text, tree):
    curr_node = tree
    result = ""
    index = 0
    while index < len(text):
        # Traverse the tree until we get to a leaf
        if text[index] == '0':
            curr_node = curr_node.left
        else:
            curr_node = curr_node.right

        if curr_node.left is None and curr_node.right is None:
            # Found the decoded letter in the leaf
            result += curr_node.letter
            curr_node = tree  # Start over again
        index += 1
    return result



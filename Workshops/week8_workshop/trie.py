# CSE 381 Workshop 8
# Tries and Auto-Complete

class Trie:

    class Node:

        def __init__(self, letter):
            self.letter = letter  # Value 
            self.children = {}    # How many other Values follow it
            self.match = False    # Does this terminate a word

    def __init__(self):
        self.root = Trie.Node("") # Start out empty

    # Wrapper to start at root
    def add(self, word):
        self.add_(word, self.root)

    def add_(self, word, node):
        # Out of letters then this node is terminating
        if len(word) == 0:
            pass
        
        # If we have seen this letter before, then follow it
        elif word[0] in node.children:
            pass

        # If we have a new letter, create it, add it to the children, and follow it
        else:
            pass

    # Wrapper to start at root and convert to boolean
    def find(self, word):
        node = self.find_(word, self.root)
        if node is None:
            return False
        return node.match  # If we found it but it wasn't terminating, then word doesn't exist

    def find_(self, word, node):
        # If we are out of letters then we found the node (might not be terminating though)
        if len(word) == 0:
            return node
        # Next letter is in the children so follow it
        elif word[0] in node.children:
            return self.find_(word[1:], node.children[word[0]])
        # Next letter not there, nothing found.
        else:
            return None

    # Wrapper to find the node and then follow it
    def possible(self, prefix):
        starting_node = self.find_(prefix, self.root)
        if starting_node is None:
            return []

        # Find all words starting from this node
        results = []
        self.possible_(prefix, starting_node, results)
        return results

    def possible_(self, prefix, node, results):
        # This is a terminating words so include it
        if node.match:
            pass

        # Follow all the children looking for more terminating words
        



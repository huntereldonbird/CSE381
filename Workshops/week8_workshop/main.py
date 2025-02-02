# CSE 381 Workshop 8
# Tries and Auto-Complete
# Don't change code in this file

import timeit
from trie import Trie

# Find all words with the same prefix
# the hard way
def list_possible(prefix, words):
    results = []
    for word in words:
        if word.startswith(prefix):
            results.append(word)
    return results

# Read the words into a list and clean them up
print("Reading words from words.txt")

with open("Workshops/week8_workshop/words.txt") as f:
    words = f.readlines()
for i in range(len(words)):
    words[i] = words[i].strip().lower()

print(f"Total Words: {len(words)}")
print()

# Load the words into the Trie
print("Loading words into the Trie")

trie = Trie()
for word in words:
    trie.add(word)    

print("Done Loading")
print()

# Shows results and timing for user entered words

while True:
    word = input("Enter word: ")
    print()

    find_via_list = word in words
    find_via_trie = trie.find(word)

    print(f"Find in List: {find_via_list}")
    print(f"Find in Trie: {find_via_trie}")
    print()

    # The timeit functions will run Python code using
    # the current enviornment (globals) 10 times (number)
    # The time is then averaged and converted to milliseconds

    time1 = timeit.timeit(stmt = "word in words", globals=globals(), number=10) * 1000 / 10
    time2 = timeit.timeit(stmt = "trie.find(word)", globals=globals(), number=10) * 1000 / 10
    print(f"Find List = {time1:.4f} ms Trie = {time2:.4f} ms")
    print()

    possible_via_list = list_possible(word,words)
    possible_via_trie = trie.possible(word)

    print(f"Possible Matches with List = {len(possible_via_list)}")
    print(f"First 10 Matches: {possible_via_list[:10]}")
    print()
    print(f"Possible Matches with Trie = {len(possible_via_trie)}")
    print(f"First 10 Matches: {possible_via_trie[:10]}")
    print()

    time1 = timeit.timeit(stmt = "list_possible(word,words)", globals=globals(), number=10) * 1000 / 10
    time2 = timeit.timeit(stmt = "trie.possible(word)", globals=globals(), number=10) * 1000 / 10
    print(f"Possible List = {time1:.4f} ms Trie = {time2:.4f} ms")
    print()



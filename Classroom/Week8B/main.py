# CSE 381 REPL 8B
# String Matcher

def build_table(pattern, inputs):
    pass
    
def match(text, pattern, inputs):
    table = build_table(pattern, inputs)
    

results = match("ABCBCABCBCBC", "CBC", ["A","B","C"])
print(results) # [4,9,11]

results = match("GTAACAGTAAACG", "AAC", ["A","C","G","T"])
print(results) # [4,11]

results = match("GTAACTAACTAGTAAACAAACTG","AACT",["A","C","G","T"])
print(results) # [5,9,21]

results = match("GTAACAGTAAACG","AACT",["A","C","G","T"])
print(results) # []
# CSE 381 REPL4C
# Radix Sort

# Added position parameter
def CreateEquals(data, rangeData, position):
    equals = [0]*rangeData
    for x in data:
        # Converting character to ASCII number
        equals[ord(x[position])] += 1
    return equals

def CreateOrder(equals, rangeData):
    order = [0]*rangeData
    # Note: order[0] = 0
    for index in range(1,rangeData):
        order[index] = equals[index - 1] + order[index - 1]
    return order

def SortPosition(data, rangeData, position):
    equals = CreateEquals(data, rangeData, position)
    order = CreateOrder(equals, rangeData)
    sorted = [0]*len(data)
    for x in data:
        sorted[order[x]] = x
        order[x] += 1
    return sorted

def Sort(data, rangeData, item_len):
    return []
        
data = ["tim", "cow", "sue", "bob", "col", "cia", "dog"]
sorted = Sort(data, 256, 3)
for x in sorted:
    print(x)
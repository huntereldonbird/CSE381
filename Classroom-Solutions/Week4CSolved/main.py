# CSE 381 REPL4C Solution
# Radix Sort

def CreateEquals(data, rangeData, position):
    equals = [0]*rangeData
    for x in data:
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
        sorted[order[ord(x[position])]] = x
        order[ord(x[position])] += 1
    return sorted

def Sort(data, rangeData, item_len):
    for position in range(item_len-1, -1, -1):
        data = SortPosition(data, rangeData, position)
        print(data)
    return data
        
data = ["tim", "cow", "sue", "bob", "col", "cia", "dog"]
sorted = Sort(data, 256, 3)
for x in sorted:
    print(x)
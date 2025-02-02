# CSE 381 REPL3B Solution
# Merge Sort

def Sort(data):
    _Sort(data, 0, len(data)-1)

def _Sort(data, first, last):
    if first >= last:  # Item of size 1 is sorted
        return
    mid = (first+last) // 2
    _Sort(data, first, mid)
    _Sort(data, mid+1, last)
    Merge(data, first, mid, last)

def Merge(data, first, mid, last):
    sa1 = data[first:mid+1]
    sa2 = data[mid+1:last+1]
    sa1Index = 0
    sa2Index = 0
    for mIndex in range(first,last+1):
        if sa1Index >= len(sa1):
            data[mIndex] = sa2[sa2Index]
            sa2Index += 1
        elif sa2Index >= len(sa2):
            data[mIndex] = sa1[sa1Index]
            sa1Index += 1
        elif sa1[sa1Index] <= sa2[sa2Index]:
            data[mIndex] = sa1[sa1Index]
            sa1Index += 1
        else:
            data[mIndex] = sa2[sa2Index]
            sa2Index += 1

data = [3,1,2,6,4,5]
Sort(data)
print(data)
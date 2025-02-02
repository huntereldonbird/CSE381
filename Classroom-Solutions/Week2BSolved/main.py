# CSE 381 REPL 2B - Solution
# Recursive Binary Search

def search(data, target):
    return _search(data, target, 0, len(data)-1)
    
def _search(data, target, first, last):
    if first > last:
        return -1
    mid = (first+last) // 2
    if data[mid] == target:
        return mid
    if data[mid] < target:
        return _search(data, target, mid+1, last)
    else:
        return _search(data, target, first, mid-1)
        

print(search([1,2,3,4,5,6],4))
print(search([1,2,3,4,5,6],0))
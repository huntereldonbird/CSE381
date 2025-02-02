# CSE 381 REPL 2A - Solution
# Binary Search

def search(data, target):
    first = 0
    last = len(data) - 1
    while first <= last:
        mid = (first + last) // 2
        if data[mid] == target:
            return mid
        if data[mid] < target:
            first = mid + 1
        elif data[mid] > target:
            last = mid - 1
    return -1

print(search([1,2,3,4,5,6],4))
print(search([1,2,3,4,5,6],0))
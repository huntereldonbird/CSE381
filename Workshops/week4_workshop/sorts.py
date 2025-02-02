# CSE 381 - Workshop 4 
# Sort Visualization

import random
from draw import draw_data

##################################
# SELECTION SORT
##################################

def selection_sort(win, data):
    for start in range(len(data) - 1):
        smallest = start
        for compare in range(start + 1, len(data)):
            if data[compare] < data[smallest]:
                smallest = compare
        data[start], data[smallest] = data[smallest], data[start]
    draw_data(win, data)

##################################
# INSERTION SORT
##################################

def insertion_sort(win, data):
    for i in range(1,len(data)):
        item = data[i]
        insert = i-1
        while insert > -1 and data[insert] > item:
            data[insert+1] = data[insert]
            insert -= 1
        data[insert+1] = item
    draw_data(win,data)

##################################
# MERGE SORT
##################################

def merge_sort(win, data):
    _merge_sort(win, data, 0, len(data)-1)
    draw_data(win, data)

def _merge_sort(win, data, first, last):
    if first >= last: 
        return
    mid = (first+last) // 2
    _merge_sort(win, data, first, mid)
    _merge_sort(win, data, mid+1, last)
    merge(win, data, first, mid, last)

def merge(win, data, first, mid, last):
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

##################################
# QUICK SORT
##################################

def quick_sort(win, data):
    _quick_sort(win, data, 0, len(data)-1)
    draw_data(win, data)

def _quick_sort(win, data, first, last):
    if first >= last: 
        return
    pivotIndex = partition(win, data, first, last)  
    _quick_sort(win, data, first, pivotIndex - 1)
    _quick_sort(win, data, pivotIndex + 1, last)

def partition(win, data, first, last):

    leftMostGreaterPivot = first;

    for index in range(first, last):
        if data[index] <= data[last]:
            data[leftMostGreaterPivot], data[index] = data[index], data[leftMostGreaterPivot]
            leftMostGreaterPivot += 1

    data[leftMostGreaterPivot], data[last] = data[last], data[leftMostGreaterPivot]
    return leftMostGreaterPivot 

##################################
# COUNTING SORT
##################################

def counting_sort(win, data, rangeData):
    equals = create_equals(data, rangeData)
    order = create_order(equals, rangeData)
    sorted = [0]*len(data)
    for x in data:
        sorted[order[x]] = x
        order[x] += 1
    draw_data(win, sorted)
    return sorted

def create_equals(data, rangeData):
    equals = [0]*rangeData
    for x in data:
        equals[x] += 1
    return equals

def create_order(equals, rangeData):
    order = [0]*rangeData
    for index in range(1,rangeData):
        order[index] = equals[index - 1] + order[index - 1]
    return order

##################################
# BOGO SORT
##################################

# You don't need to modify these functions below

def is_sorted(data):
    for i in range(1,len(data)):
        if data[i-1] > data[i]:
            return False
    return True

def bogo_sort(win, data):
    while not is_sorted(data):
        index1 = random.randint(0,len(data)-1)
        index2 = random.randint(0,len(data)-1)
        data[index1], data[index2] = data[index2], data[index1]
        draw_data(win,data,index1)
    draw_data(win,data)
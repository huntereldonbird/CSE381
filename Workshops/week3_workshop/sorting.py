# CSE 381 Workshop 3

import requests

# Perform merge sort using the key lambda when 
# doing comparisons. 
def Sort(data):
    _Sort(data, 0, len(data)-1)

# Recursive call for merge sort.  Provide the key
# lambda to all functions
def _Sort(data, first, last):
    if first >= last:  # Item of size 1 is sorted
        return
    mid = (first+last) // 2
    _Sort(data, first, mid)
    _Sort(data, mid+1, last)
    Merge(data, first, mid, last)

# Merge two sorted lists together.  The key lambda
# is needed here to do the comparison
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

def print_book(book):
    print(f"{book["title"]:<50}{book["author"]:<28}{book["language"]:<18}{book["year"]:<5}")

# Read the book API and convert to a list of dictionaries
# Contains the keys: title, author, language, year
book_url = "https://raw.githubusercontent.com/benoitvallon/100-best-books/master/books.json"
book_list = requests.get(book_url).json()

# Do your sorting here


# Display the books
for book in book_list:
    print_book(book)



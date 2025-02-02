# CSE 381 - Workshop 4 
# Sort Visualization

import random
import sys
import time
import pygame
from sorts import selection_sort, insertion_sort, merge_sort, quick_sort, counting_sort, bogo_sort

pygame.init()
win = pygame.display.set_mode((1000,500))

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()

    data = [random.randint(0,499) for _ in range(100)]

    pygame.display.set_caption("Selection Sort")
    selection_sort(win, data[:])
    time.sleep(5)

    # pygame.display.set_caption("Insertion Sort")
    # insertion_sort(win, data[:])
    # time.sleep(5)

    # pygame.display.set_caption("Merge Sort")
    # merge_sort(win, data[:])
    # time.sleep(5)

    # pygame.display.set_caption("Quick Sort")
    # quick_sort(win, data[:])
    # pygame.time.delay(5000)

    # pygame.display.set_caption("Counting Sort")
    # counting_sort(win, data[:], 500)
    # time.sleep(5)




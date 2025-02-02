# CSE 381 - Workshop 4 
# You will not need to change this file

import pygame
import sys

def draw_data(win, data, highlight=-1):
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()
    win.fill((255,255,255))
    for index in range(len(data)):
        if index == highlight:
            color = (255,255,0)
        else:
            color = (100,0,0)
        pygame.draw.rect(win, color, (index*10,500-data[index],10,data[index]))
    pygame.display.update()
    pygame.time.delay(10)
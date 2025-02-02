# CSE381 Week 11A Solution
# Convex Hull

from math import atan2, sqrt
import matplotlib.pyplot as plt
import functools
import random

COLINEAR = 0
CONVEX = 1
CONCAVE = 2

class Point:

    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __str__(self):
        return f"({self.x},{self.y})"

def points_to_str(points):
    return functools.reduce(
        lambda result, p : f"{result}{p}, ", 
        points, "")[:-2]

def orientation(a, b, c):
    cross_prod = (b.x - a.x) * (c.y - b.y) - (b.y - a.y) * (c.x - b.x)
    if cross_prod == 0:
        return COLINEAR
    elif cross_prod > 0:
        return CONVEX
    else:
        return CONCAVE

def get_angle(anchor, point):
    return atan2(point.y - anchor.y, point.x - anchor.x)

def get_dist(anchor, point):
    return sqrt((point.x - anchor.x)**2 + (point.y - anchor.y)**2)

def get_convex_hull(points):
    print(f"Points: {points_to_str(points)}")
    if len(points) < 3:
        # Convex hull is not possible with less than 3 points
        return []

    # Find the point with the lowest y-coordinate (and leftmost if ties)
    anchor = min(points, key=lambda point: (point.y, point.x))
    print(f"Anchor: {anchor}")

    # Sort the points by angle and distance relative to the anchor
    sorted_points = sorted(points, 
                           key=lambda point: (get_angle(anchor, point), 
                                              get_dist(anchor, point)))
    print(f"Sorted Points: {points_to_str(sorted_points)}")

    # Initialize the convex hull with the anchor
    hull = [sorted_points[0]]

    # Iterate through the sorted points to build the convex hull
    # Start at index 1 (since the anchor is already added)
    for i in range(1, len(sorted_points)):

        while True:

            # We need 3 points to determine orientation, so if we only have 1,
            # then add the point to the hull.
            if len(hull) == 1:
                hull.append(sorted_points[i])
                break

            # If new points is convex, then add it.
            # If not, then remove the previous point and reconsider
            else:
                result = orientation(hull[-2], hull[-1], sorted_points[i])
                if result == CONVEX:
                    hull.append(sorted_points[i])
                    break
                else:
                    hull.pop()

    # Need at least 3 points to make a proper hull
    if len(hull) <= 2:
        return []                    
        
    # Re-add the anchor so we have a cycle
    hull += [hull[0]]
    return hull

def plot_points_with_hull(points, convex_hull, show_angles=False):
    xs = [p.x for p in points]
    ys = [p.y for p in points]
    plt.scatter(xs, ys, color='b')

    if show_angles and len(convex_hull) > 0:
        anchor = convex_hull[0]
        for point in points:
            plt.plot([anchor.x,point.x],[anchor.y,point.y], color='r')

    xs2 = [p.x for p in convex_hull]
    ys2 = [p.y for p in convex_hull]
    plt.plot(xs2,ys2,color='g')
    plt.show()


# Simple Example
points = [Point(0,0),Point(4,0),Point(3,1),Point(1,1),Point(8,8),Point(3,6),
          Point(1,4),Point(1,3),Point(0,4),Point(0,2),Point(5.5,7)]

# Colinear Example - No Hull
points = [Point(0,0),Point(1,1),Point(2,2),Point(3,3),Point(4,4)]

# Almost Colinear Example
points = [Point(0,0),Point(1,1),Point(2,2),Point(3,3),Point(4,4),Point(5,6)]

# Too Small - No Hull
points = [Point(0,0),Point(1,0)]

# Random Example
points = [Point(random.randint(0,100),random.randint(0,100)) for _ in range(100)]

# Simple Art
points = [Point(2,2),Point(3,3),Point(4,4),Point(6,4),Point(7,3),Point(8,2),
          Point(5,5),Point(5,6),Point(5,7),Point(5,8),Point(5,9),Point(5,10),
          Point(5,11),Point(4,11),Point(3,11),Point(2,12),Point(1,13),
          Point(6,11),Point(7,11),Point(8,12),Point(9,13),Point(5,12),
          Point(5,13),Point(5,14),Point(5,15),Point(5,16),Point(5,17),
          Point(4,17),Point(3,18),Point(2,19),Point(2,20),Point(2,21),
          Point(2,22),Point(2,23),Point(2,24),Point(2,25),Point(3,26),
          Point(4,27),Point(5,27),Point(6,27),Point(7,26),Point(8,25),
          Point(8,24),Point(8,23),Point(8,22),Point(8,21),Point(8,20),
          Point(8,19),Point(7,18),Point(6,17),Point(4,20),Point(5,19),
          Point(6,20),Point(4,24),Point(6,24)]

convex_hull = get_convex_hull(points)
print(f"Convex Hull: {points_to_str(convex_hull)}")

# Set to True if you want to view lines connecting to anchor
plot_points_with_hull(points, convex_hull, True)

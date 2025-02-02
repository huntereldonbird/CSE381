# CSE 381 Workshop 9
# Encrypt Files
# Do not modify this code

def euclid(a, b):
    if b == 0:
        return (a, 1, 0)
    (gcd, i, j) = euclid(b, a % b)
    return (gcd, j, i - (a//b) * j)

def generatePrivateKey(p, q, e):
    phi = (p-1) * (q-1)
    (gcd, s, _) = euclid(e, phi)
    # NOTE: Python does the % of negative as we would expect
    # However, to be like C#:
    return ((s % phi) + phi) % phi

def modulo_expo(x, y, n):
    if y == 0:
        return 1
    if y % 2 == 0:
        z = modulo_expo(x, y//2, n) 
        return (z * z) % n
    else:
        z = modulo_expo(x, (y-1)//2, n)
        return (z * z * x) % n
    
def encrypt(value, e, n):
    return modulo_expo(value,e,n)

def decrypt(value, d, n):
    return modulo_expo(value,d,n)
# CSE 381 REPL 9B Solution
# RSA

def euclid(a, b):
    if b == 0:
        return (a, 1, 0)
    (gcd, i, j) = euclid(b, a % b)
    return (gcd, j, i - (a//b) * j)

def generatePrivateKey(p, q, e):
    phi = (p-1) * (q-1)
    (gcd, i, _) = euclid(e, phi)
    # NOTE: Python does the % of negative as we would expect
    # However, to be like C#:
    return ((i % phi) + phi) % phi

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
    # return (value ** e) % n
    return modulo_expo(value,e,n)

def decrypt(value, d, n):
    # return (value ** d) % n
    return modulo_expo(value,d,n)

p = 17
q = 11
n = p*q
e = 7
d = generatePrivateKey(p, q, e)
#data = 188  -- Must be less than n
data = 42
print(f"Original data = {data}")
e_data = encrypt(data, e, n)
print(f"Encrypted data = {e_data}")
d_data = decrypt(e_data, d, n)
print(f"Decrypted data = {d_data}")

print("---------")

p = 29
q = 43
n = p*q
e = 5
d = generatePrivateKey(p, q, e)
data = 42
print(f"Original data = {data}")
e_data = encrypt(data, e, n)
print(f"Encrypted data = {e_data}")
d_data = decrypt(e_data, d, n)
print(f"Decrypted data = {d_data}")

print("---------")

p = 87178291199
q = 22815088913
n = p*q
e = 65537
d = generatePrivateKey(p, q, e)
data = 42
print(f"Original data = {data}")
e_data = encrypt(data, e, n)
print(f"Encrypted data = {e_data}")
d_data = decrypt(e_data, d, n)
print(f"Decrypted data = {d_data}")




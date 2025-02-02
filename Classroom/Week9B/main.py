# CSE 381 REPL 9B 
# RSA

def euclid(a, b):
    if b == 0:
        return (a, 1, 0)
    (gcd, i, j) = euclid(b, a % b)
    return (gcd, j, i - (a//b) * j)

def generatePrivateKey(p, q, e):
    pass

def encrypt(value, e, n):
    pass
    
def decrypt(value, d, n):
    pass
    
p = 17
q = 11
n = p*q
e = 7
d = generatePrivateKey(p, q, e)
#data = 188
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

# p = 87178291199
# q = 22815088913
# n = p*q
# e = 65537
# d = generatePrivateKey(p, q, e)
# data = 42
# print(f"Original data = {data}")
# e_data = encrypt(data, e, n)
# print(f"Encrypted data = {e_data}")
# d_data = decrypt(e_data, d, n)
# print(f"Decrypted data = {d_data}")




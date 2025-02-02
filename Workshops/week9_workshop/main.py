# CSE 381 Workshop 9
# Encrypt Files

from rsa import encrypt, decrypt, generatePrivateKey
import random

# p and q are 100-digit primes
# e is co-prime with phi = (p-1)*(q-1)


p = 2074722246773485207821695222107608587480996474721117292752992589912196684750549658310084416732550077
q = 6513516734600035718300327211250928237178281758494417357560086828416863929270451437126021949850746381
e = 5945270277430017699389071915534874484280242574746323799752862797471282696460708934032437956646666052239897676025355511780981133946170806055885507836169256331067191421320772938883150656468379131013339

# NOTE: Public Keys: e and n
#       Private Key: d

n = None
d = None

# Encrypting each letter separately

with open("Workshops/week9_workshop/poem.txt","r") as fd:
    # Read Unecrypted File
    pass

# with open("Workshops/week9_workshop/poem.enc","w") as fd:
#     # Encrypt and Write to Encrypted File
#     pass

# with open("Workshops/week9_workshop/poem.enc","r") as fd:
#     # Read Encrypted File
#     pass

# with open("Workshops/week9_workshop/poem_decrypted.txt","w") as fd:
#     # Decrypt and Write to Unecrypted File
#     pass
        

# Encrypting whole file into a single value

# with open("Workshops/week9_workshop/poem.txt","rb") as fd:
#     # Read Unecrypted File
#     pass

# with open("Workshops/week9_workshop/poem.enc2","wb") as fd:
#     # Encrypt and Write to Encrypted File
#     pass

# with open("Workshops/week9_workshop/poem.enc2","rb") as fd:
#     # Read Encrypted File
#     pass

# with open("Workshops/week9_workshop/poem_decrypted2.txt", "wb") as fd:
#     # Decrypt and Write to Unecrypted File
#     pass

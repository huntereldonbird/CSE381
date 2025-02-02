# CSE 381 Workshop 10
# File Compression

import functools
import pickle
from huffman import profile, build_tree, create_encoding_map
from huffman import encode, decode

def convert_to_bit_stream(bit_string):
    """
    Convert string 0 and 1 to bits 0 and 1.  8 bits will 
    be processed at a time with each result being put into
    a byte array.  The last group of 8 bits might be shorter
    but that will be okay.
    """
    start = 0
    result = bytearray()
    while start < len(bit_string):
        # Take blocks of 8 bits at a time and interpret them in base 2
        # This integer is then converted to a byte and stored in the bytearray.
        num = int(bit_string[start:start+8], 2)
        result.append(num)
        start += 8
    return result

def convert_from_bit_stream(byte_array):
    """
    Convert a byte array into a string of bits 0 and 1.  Each
    byte is 8 bits long but since we need a string of bits, 
    we will need to add some 0 bit padding to the left to ensure
    we actually have 8 bits.  We won't add the padding to the last
    byte because bits those additional bits were not in the original bit string.
    """
    result = ""
    for index in range(len(byte_array)):
        # For each byte, convert to a string of 1's and 0's
        # Remove the '0b' from the front. We need to have the
        # leading 0's added back.  However, for the last byte,
        # we shouldn't add additional 0's.
        binary = bin(byte_array[index])[2:]
        if index < len(byte_array)-1:
            # Add some padding to the left
            binary = binary.zfill(8)
        result += binary
    return result

def compress():

    print("Reading file...")
    

    print("Profiling, Building Huffman Tree, and Creating Encoding Map...")


    print("Compressing and Writing file...")


def decompress():    

    print("Reading Zip file...")


    print("Decompressing and Writing file...")

    

# Functions separated to simulate actual compression and
# decompression being done at different times.
compress()
decompress()
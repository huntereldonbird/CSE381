/* CSE 381 - RSA 
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Euclid, ModularExponentiation, GeneratePrivateKey,
*  Encrypt, and Decrypt functions per the instructions in the comments.  
*  Run all tests in RSATest.cs to verify your code.
*/

using System.Numerics;

namespace AlgorithmLib;

public class RSA
{
    /* Recursively use Euclid to find the Greatest Common Divisor between
     * two numbers as well as the linear combination form.
     *
     *  Inputs:
     *     a - First number
     *     b - Second number
     *  Outputs:
     *     (gcd, i, j) where gcd = i*a + j*b
     */
    public static (BigInteger, BigInteger, BigInteger) Euclid(BigInteger a, BigInteger b) {


        // base case
        if (b == 0) {
            return (a, 1, 0);
        }

        //find the gcd, then pass it through one more time to both check ^, then we should return after...
        var (gcd, out1, out2) = Euclid(b, a % b);
        return (gcd, out2, (out1 - (a / b) * out2));

    }

    /* Recursively calculates x^y mod n
     *
     *  Inputs:
     *     x - base
     *     y - exponent
     *     n - modulo
     *  Outputs:
     *     Result of x^y mod n
     */
    public static BigInteger ModularExponentiation(BigInteger x, BigInteger y, BigInteger n) {


        // base case
        if (y == 0) {
            return 1;
        }
        // find the exponential of the function, if it is even..(y % 2 = 0), then we should take that factor(2), out
        if (y % 2 == 0) {
            var z = ModularExponentiation(x, y/2, n);
            return (z * z) % n;
        }
        else {
            var z = ModularExponentiation(x, y -1, n);
            return (x * z) % n;
        }

    }

    /* Generate the RSA private key given the two prime numbers p and q and
     * the public key e which was selected to be co-prime with
     * r = (p-1) * (q-1).
     * 
     *  Inputs:
     *     p - First prime
     *     q - Second prime
     *     e - Public Key 
     *  Outputs:
     *     Private Key - Must be positive
     */
    public static BigInteger GeneratePrivateKey(BigInteger p, BigInteger q, BigInteger e) {

        // we are looking for teh private key that works for e*d===1


        var phi = (p - 1) * (q - 1);

        // get the gcd
        var (gcd, d, _) = Euclid(e, phi);

        d = ((d % phi) + phi) % phi;

        return d;

    }

    /* Encrypt a value using the public keys e and n
     *
     *  Inputs:
     *     value - Value to encrypt
     *     e - Value that was co-prime with (p-1)*(q-1)
     *     n - Value equal to p*q
     *  Outputs:
     *     encrypted value
     */
    public static BigInteger Encrypt(BigInteger value, BigInteger e, BigInteger n) {
        return ModularExponentiation(value, e, n);
    }

    /* Decrypt a value using the public key n and private key d
     *
     *  Inputs:
     *     value - Value to decrypt
     *     e - Private Key
     *     n - Value equal to p*q
     *  Outputs:
     *     encrypted value
     */
    public static BigInteger Decrypt(BigInteger value, BigInteger d, BigInteger n) {
        return ModularExponentiation(value, d, n);
    }


}
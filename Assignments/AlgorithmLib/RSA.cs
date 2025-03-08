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

        if (b == 0) {
            return (a, 1, 0);
        }

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

        if (y == 0) {
            return 1;
        }

        if (y % 2 == 0) {
            var z = ModularExponentiation(x, y/2, n);
            return ((BigInteger.Pow(z, 2) % n) + n % n);
        }
        else {
            var z = ModularExponentiation(x, y -1, n);
            return BigInteger.Pow(z, 2) * x;
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

        // var phi = (p-1) * (q - 1);
        // var i = Euclid(e, phi);
        //
        // return ((i.Item2 % phi) + phi % phi); // correct way to mod for in c# i guess?

        var n = p * q;
        var phi = (p - 1) * (q - 1);

        for (int i = 0; i < e; i++) {

            if (Euclid(e, phi).Item1 == 1) {
                break;
            }


        }




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
        //return (((BigInteger)Math.Pow((double)value, (double)e) % n) + n % n);

        int res = 1;
        value = value % n;

        var expo;

        while expo > 1
        {

        }


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
        return (((BigInteger)Math.Pow((double)value, (double)d) % n) + n % n);

    }


}
/*  CSE 381 - RSA Test
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. W5.
 *
 *  Instructions: Do not modify this file.  Use these test to verify
 *  that your code is working properly.
*/

using System.Numerics;
using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class RSATest
{

    [Test]
    public void Test1_EuclidSmall()
    {
        BigInteger a = 8;
        BigInteger b = 12;
        var (gcd, i, j) = RSA.Euclid(a, b);
       
        Assert.That(gcd, Is.EqualTo(BigInteger.Parse("4")));
        Assert.That(i, Is.EqualTo(BigInteger.Parse("-1")));
        Assert.That(j, Is.EqualTo(BigInteger.Parse("1")));
    }
    
    [Test]
    public void Test2_EuclidCoprimeSmall()
    {
        BigInteger p = 7;
        BigInteger q = 13;
        BigInteger r = (p - 1) * (q - 1);
        BigInteger e = 5; // relatively prime to r
        var (gcd, i, j) = RSA.Euclid(e, r);
        Console.WriteLine($"{gcd} {i} {j}");
       
        Assert.That(gcd, Is.EqualTo(BigInteger.Parse("1")));
        Assert.That(i, Is.EqualTo(BigInteger.Parse("29")));
        Assert.That(j, Is.EqualTo(BigInteger.Parse("-2")));
    }

    [Test]
    public void Test3_EuclidCoprimeBig()
    {
        BigInteger p = 87178291199;
        BigInteger q = 22815088913;
        BigInteger r = (p - 1) * (q - 1);
        BigInteger e = 65537; // relatively prime to r
        var (gcd, i, j) = RSA.Euclid(e, r);
       
        Assert.That(gcd, Is.EqualTo(BigInteger.Parse("1")));
        Assert.That(i, Is.EqualTo(BigInteger.Parse("-691197798001282429727")));
        Assert.That(j, Is.EqualTo(BigInteger.Parse("22775")));
    }
    
    [Test]
    public void Test4_GeneratePrivateKey()
    {
        BigInteger p = 87178291199;
        BigInteger q = 22815088913;
        BigInteger e = 65537; // relatively prime to (p-1)*(q-1)
        BigInteger privateKey = RSA.GeneratePrivateKey(p, q, e);
        Assert.That(privateKey.Equals(BigInteger.Parse("1297782666877314566849")), Is.True);
    }
    
    [Test]
    public void Test5_Encrypt()
    {
        BigInteger p = 87178291199;
        BigInteger q = 22815088913;
        BigInteger e = 65537; // relatively prime to (p-1)*(q-1)
        BigInteger n = p * q;
        BigInteger value = 42;
        BigInteger privateKey = RSA.GeneratePrivateKey(p, q, e);
        BigInteger encrypted = RSA.Encrypt(value, e, n);
        Assert.That(encrypted.Equals(BigInteger.Parse("475967911669796538187")));
    }

    [Test]
    public void Test6_Decrypt()
    {
        BigInteger p = 87178291199;
        BigInteger q = 22815088913;
        BigInteger e = 65537; // relatively prime to (p-1)*(q-1)
        BigInteger n = p * q;
        BigInteger value = 42;
        BigInteger privateKey = RSA.GeneratePrivateKey(p, q, e);
        BigInteger encrypted = RSA.Encrypt(value, e, n);
        BigInteger decrypted = RSA.Decrypt(encrypted, privateKey, n);
        Assert.That(decrypted.Equals(BigInteger.Parse("42")));
    }
    
}
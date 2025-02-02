// CSE 381 REPL 9A Solution
// Euclid Algorithm

using System.Numerics;

public class RSA
{
    public static (BigInteger, BigInteger, BigInteger) Euclid(BigInteger a, BigInteger b)
    {
        if (b == 0)
        {
            return (a, 1, 0);
        }

        var (gcd, i, j) = Euclid(b, a % b);
        return (gcd, j, i - (a/b) * j);
    }

    public static BigInteger ModInverse(BigInteger i, BigInteger b)
    {
        return ((i % b) + b) % b;
    }
}

class Program
{
    public static void Main(string[] args) 
    {
        var a = 10;
        var b = 21;
        Console.WriteLine($"a = {a} b = {b}");
        var (gcd,i,j) = RSA.Euclid(a,b);
        Console.WriteLine($"gcd = {gcd} i = {i} j = {j}"); 
        var d = RSA.ModInverse(i,b);
        Console.WriteLine($"d (inverse) = {d}");
        Console.WriteLine($"(d * a) mod b = {(d*a) % b}");

        Console.WriteLine("----");

        a = 28;
        b = 63;
        Console.WriteLine($"a = {a} b = {b}");
        (gcd,i,j) = RSA.Euclid(a,b);
        Console.WriteLine($"gcd = {gcd} i = {i} j = {j}"); 
        d = RSA.ModInverse(i,b);
        Console.WriteLine($"d (inverse) = {d}");
        Console.WriteLine($"(d * a) mod b = {(d*a) % b}");

        Console.WriteLine("----");
        
        a = 147;
        b = 1375;
        Console.WriteLine($"a = {a} b = {b}");
        (gcd,i,j) = RSA.Euclid(a,b);
        Console.WriteLine($"gcd = {gcd} i = {i} j = {j}"); 
        d = RSA.ModInverse(i,b);
        Console.WriteLine($"d (inverse) = {d}");
        Console.WriteLine($"(d * a) mod b = {(d*a) % b}");
        Console.WriteLine("----");
        
        a = 7;
        b = 160;
        Console.WriteLine($"a = {a} b = {b}");
        (gcd,i,j) = RSA.Euclid(a,b);
        Console.WriteLine($"gcd = {gcd} i = {i} j = {j}"); 
        d = RSA.ModInverse(i,b);
        Console.WriteLine($"d (inverse) = {d}");
        Console.WriteLine($"(d * a) mod b = {(d*a) % b}");

        Console.WriteLine("----");
        
        a = 5;
        b = 1176;
        Console.WriteLine($"a = {a} b = {b}");
        (gcd,i,j) = RSA.Euclid(a,b);
        Console.WriteLine($"gcd = {gcd} i = {i} j = {j}"); 
        d = RSA.ModInverse(i,b);
        Console.WriteLine($"d (inverse) = {d}");
        Console.WriteLine($"(d * a) mod b = {(d*a) % b}");
    }
}
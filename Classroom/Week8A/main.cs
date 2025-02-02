// CSE 381 REPL 8A 
// Longest Common Subsequence

public static class LongestCommonSubsequence 
{

    private static int[,] compute_table(string x, string y)
    {
        var table = new int[x.Length+1, y.Length+1];

        return table;
    }

    private static string lcs_from_table(string x, string y, int[,] table, int i, int j)
    {
        return "";
    }

    public static string find(string x, string y)
    {
        var table = compute_table(x, y);
        var lcs = lcs_from_table(x, y, table, x.Length, y.Length);
        return lcs;
    }
}

class Program
{
    public static void Main(string[] args) 
    {

        var result = LongestCommonSubsequence.find("CATCGA", "GTACCGTCA");
        Console.WriteLine(result);    
        result = LongestCommonSubsequence.find("HCATCHGA", "HGTACCGTCA");
        Console.WriteLine(result);

    }
}
// CSE 381 REPL 8A Solution
// Longest Common Subsequence

public static class LongestCommonSubsequence
{
    private static int[,] compute_table(string x, string y)
    {
        var table = new int[x.Length+1, y.Length+1];
        for (var i = 0; i <= x.Length; i++)
        {
            table[i, 0] = 0;
        }

        for (var j = 0; j <= y.Length; j++)
        {
            table[0, j] = 0;
        }

        for (var i = 1; i <= x.Length; i++)
        {
            for (var j = 1; j <= y.Length; j++)
            {
                if (x[i-1] == y[j-1])
                {
                    table[i, j] = table[i - 1, j - 1] + 1;
                }
                else
                {
                    table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }
        }

        return table;
    }

    private static string lcs_from_table(string x, string y, int[,] table, int i, int j)
    {
        if (table[i, j] == 0)
        {
            return "";
        }

        if (x[i-1] == y[j-1])
        {
            return lcs_from_table(x, y, table, i - 1, j - 1) + x[i-1];
        }

        // The order we check here will affect the LCS selected
        if (table[i - 1, j] > table[i, j - 1]) 
        {
            return lcs_from_table(x, y, table, i - 1, j);
        }
        else
        {
            return lcs_from_table(x, y, table, i, j - 1);
        }
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
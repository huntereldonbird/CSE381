/*  CSE 381 - String Matcher (KMP) Test
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. W5.
 *
 *  Instructions: Do not modify this file.  Use these test to verify
 *  that your code is working properly.
*/

using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class StringMatcherTest
{
    [Test]
    public void Test1_BuildTable1()
    {
        var results = StringMatcher.BuildTable("AAC", new List<char> { 'A', 'C', 'G', 'T' });
        Assert.That(results[0]['A'],Is.EqualTo(1));
        Assert.That(results[0]['C'],Is.EqualTo(0));
        Assert.That(results[0]['G'],Is.EqualTo(0));
        Assert.That(results[0]['T'],Is.EqualTo(0));
        Assert.That(results[1]['A'],Is.EqualTo(2));
        Assert.That(results[1]['C'],Is.EqualTo(0));
        Assert.That(results[1]['G'],Is.EqualTo(0));
        Assert.That(results[1]['T'],Is.EqualTo(0));
        Assert.That(results[2]['A'],Is.EqualTo(2));
        Assert.That(results[2]['C'],Is.EqualTo(3));
        Assert.That(results[2]['G'],Is.EqualTo(0));
        Assert.That(results[2]['T'],Is.EqualTo(0));
        Assert.That(results[3]['A'],Is.EqualTo(1));
        Assert.That(results[3]['C'],Is.EqualTo(0));
        Assert.That(results[3]['G'],Is.EqualTo(0));
        Assert.That(results[3]['T'],Is.EqualTo(0));
        Assert.That(results.Count, Is.EqualTo(4));
        Assert.Pass();
    }
    
    [Test]
    public void Test2_BuildTable2()
    {
        var results = StringMatcher.BuildTable("CBCBA", new List<char> { 'A', 'B', 'C'});
        Assert.That(results[0]['A'],Is.EqualTo(0));
        Assert.That(results[0]['B'],Is.EqualTo(0));
        Assert.That(results[0]['C'],Is.EqualTo(1));
        Assert.That(results[1]['A'],Is.EqualTo(0));
        Assert.That(results[1]['B'],Is.EqualTo(2));
        Assert.That(results[1]['C'],Is.EqualTo(1));
        Assert.That(results[2]['A'],Is.EqualTo(0));
        Assert.That(results[2]['B'],Is.EqualTo(0));
        Assert.That(results[2]['C'],Is.EqualTo(3));
        Assert.That(results[3]['A'],Is.EqualTo(0));
        Assert.That(results[3]['B'],Is.EqualTo(4));
        Assert.That(results[3]['C'],Is.EqualTo(1));
        Assert.That(results[4]['A'],Is.EqualTo(5));
        Assert.That(results[4]['B'],Is.EqualTo(0));
        Assert.That(results[4]['C'],Is.EqualTo(3));
        Assert.That(results[5]['A'],Is.EqualTo(0));
        Assert.That(results[5]['B'],Is.EqualTo(0));
        Assert.That(results[5]['C'],Is.EqualTo(1));
        Assert.That(results.Count, Is.EqualTo(6));
        
        Assert.Pass();
    }
    
    [Test]
    public void Test3_Match1()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AAC", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int> { 4, 11 };
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test4_Match2()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AA", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int> { 3, 9, 10 };
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test5_Match3()
    {
        var results = StringMatcher.Match("ABCBCABCBCBC", "CBC", new List<char> { 'A', 'B', 'C'});
        var expected = new List<int> { 4, 9, 11};
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }

    [Test]
    public void Test6_NoMatches()
    {
        var results = StringMatcher.Match("GTAACAGTAAACG", "AACT", new List<char> { 'A', 'C', 'G', 'T' });
        var expected = new List<int>();
        Assert.That(expected.SequenceEqual(results), Is.True);
        Assert.Pass();
    }
    

}
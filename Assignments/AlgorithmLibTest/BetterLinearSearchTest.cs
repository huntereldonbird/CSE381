/*  CSE 381 - Better Linear Test
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
public class BetterLinearSearchTest
{
    [Test]
    public void Test1_MatchNumber()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6 };
        var index = BetterLinearSearch.Search(list, 4);
        Assert.That(index, Is.EqualTo(3));
        Assert.Pass();
    }
    
    [Test]
    public void Test2_NoMatchNumber()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6 };
        var index = BetterLinearSearch.Search(list, 8);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test3_MatchString()
    {
        var list = new List<string> { "cat", "dog", "pig", "chicken", "duck" };
        var index = BetterLinearSearch.Search(list, "pig");
        Assert.That(index, Is.EqualTo(2));
        Assert.Pass();
    }
    
    [Test]
    public void Test4_NoMatchString()
    {
        var list = new List<string> { "cat", "dog", "pig", "chicken", "duck" };
        var index = BetterLinearSearch.Search(list, "eagle");
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test5_Empty()
    {
        var list = new List<int>();
        var index = BetterLinearSearch.Search(list, 42);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
}
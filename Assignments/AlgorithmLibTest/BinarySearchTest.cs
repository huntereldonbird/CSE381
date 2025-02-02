/*  CSE 381 - Binary Search Test
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. W5.
 *
 *  Instructions: Do not modify this file.  Use these test to verify
 *  that your code is working properly.
*/

namespace AlgorithmLibTest;
using AlgorithmLib;
using NUnit.Framework;

[TestFixture]
public class BinarySearchTest
{
    [Test]
    public void Test1_MatchFirst()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 1);
        Assert.That(index, Is.EqualTo(0));
        Assert.Pass();
    }
    
    [Test]
    public void Test2_MatchLast()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 15);
        Assert.That(index, Is.EqualTo(6));
        Assert.Pass();
    }
    
    [Test]
    public void Test3_MatchMiddle()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 7);
        Assert.That(index, Is.EqualTo(3));
        Assert.Pass();
    }
    
    [Test]
    public void Test4_NoMatchTooBig()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 20);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test5_NoMatchTooSmall()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 0);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test6_NoMatchMiddle()
    {
        var data = new List<int> { 1, 3, 6, 7, 11, 13, 15 };
        var index = BinarySearch.Search(data, 4);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
    [Test]
    public void Test7_Empty()
    {
        var empty = new List<int>();
        var index = BinarySearch.Search(empty,7);
        Assert.That(index, Is.EqualTo(-1));
        Assert.Pass();
    }
    
}
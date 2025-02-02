/*  CSE 381 - Merge Sort Test
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
public class MergeSortTest
{
    
    [Test]
    public void Test1_MergeEqualSizedSublists()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 4, 6, 7, 8, 2, 3, 5, 9, 10};
        MergeSort.Merge(starting, 1, 4, 8);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }

    [Test]
    public void Test2_MergeUnequalSizedSublists1()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 4, 6, 7, 8, 9, 2, 3, 5, 10};
        MergeSort.Merge(starting, 1, 5, 8);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test3_MergeUnequalSizedSublists2()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 2, 4, 6, 3, 5, 7, 8, 9, 10};
        MergeSort.Merge(starting, 1, 3, 8);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test4_MergeAlreadySorted()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        MergeSort.Merge(starting, 1, 4, 8);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test5_MergeSmall1()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 2, 3, 4, 6, 5, 7, 8, 9, 10};
        MergeSort.Merge(starting, 4, 4, 6);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }

    [Test]
    public void Test6_MergeSmall2()
    {
        var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        var starting = new List<int> { 1, 2, 3, 4, 6, 7, 5, 8, 9, 10};
        MergeSort.Merge(starting, 4, 5, 6);
        Assert.That(starting.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }

    
    [Test]
    public void Test7_SortEvenCount()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        int[] unsortedArray = { 3, 5, 2, 6, 1, 4 };
        var data = new List<int>(unsortedArray);
        MergeSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test8_SortOddCount()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7 };
        int[] unsortedArray = { 3, 5, 7, 2, 6, 1, 4 };
        var data = new List<int>(unsortedArray);
        MergeSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test9_AlreadySorted()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        var data = new List<int>(sortedArray);
        MergeSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    
    [Test]
    public void Test10_Empty()
    {
        int[] sortedArray = Array.Empty<int>();
        var data = new List<int>();
        MergeSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
}
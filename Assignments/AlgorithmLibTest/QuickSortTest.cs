/*  CSE 381 - Quick Sort Test
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
public class QuickSortTest
{
    
    [Test]
    public void Test1_PartitionPositionMiddle()
    {
        var expected = new List<int> { 3, 1, 2, 0, 4, 9, 5, 7, 6, 8 };
        var array = new List<int> { 3, 8, 1, 9, 2, 0, 5, 7, 6, 4 };
        var result = QuickSort.Partition(array, 0, 9);
        Assert.That(result, Is.EqualTo(4));
        Assert.That(array.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test2_PartitionPositionStart()
    {
        var expected = new List<int> { 0, 8, 1, 4, 2, 9, 5, 7, 6, 3 };
        var array = new List<int> { 3, 8, 1, 4, 2, 9, 5, 7, 6, 0 };
        var result = QuickSort.Partition(array, 0, 9);
        Assert.That(result, Is.EqualTo(0));
        Assert.That(array.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test3_PartitionPositionEnd()
    {
        var expected = new List<int> { 3, 8, 1, 4, 2, 0, 5, 7, 6, 9 };
        var array = new List<int> { 3, 8, 1, 4, 2, 0, 5, 7, 6, 9 };
        var result = QuickSort.Partition(array, 0, 9);
        Assert.That(result, Is.EqualTo(9));
        Assert.That(array.SequenceEqual(expected), Is.True);
        Assert.Pass();
    }

    [Test]
    public void Test4_Sort()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        int[] unsortedArray = { 3, 5, 2, 6, 1, 4 };
        var data = new List<int>(unsortedArray);
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    [Test]
    public void Test5_AlreadySorted()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6 };
        var data = new List<int>(sortedArray);
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
    
    
    [Test]
    public void Test6_Empty()
    {
        int[] sortedArray = Array.Empty<int>();
        var data = new List<int>();
        QuickSort.Sort(data);
        Assert.That(data.SequenceEqual(sortedArray), Is.True);
        Assert.Pass();
    }
}
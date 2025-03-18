/*  CSE 381 - Huffman Tree Test
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. W5.
 *
 *  Instructions: Do not modify this file.  Use these test to verify
 *  that your code is working properly.
*/

#pragma warning disable CS8602   // Dereference of a possibly null reference.

using AlgorithmLib;
using NUnit.Framework;

namespace AlgorithmLibTest;

[TestFixture]
public class HuffmanTreeTest
{



    [Test]
    public void Test2_Profile()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        Assert.That(profile['t'], Is.EqualTo(3));
        Assert.That(profile['h'], Is.EqualTo(2));
        Assert.That(profile['e'], Is.EqualTo(2));
        Assert.That(profile[' '], Is.EqualTo(8));
        Assert.That(profile['r'], Is.EqualTo(1));
        Assert.That(profile['a'], Is.EqualTo(5));
        Assert.That(profile['i'], Is.EqualTo(6));
        Assert.That(profile['n'], Is.EqualTo(6));
        Assert.That(profile['s'], Is.EqualTo(3));
        Assert.That(profile['p'], Is.EqualTo(2));
        Assert.That(profile['y'], Is.EqualTo(2));
        Assert.That(profile['m'], Is.EqualTo(1));
        Assert.That(profile['l'], Is.EqualTo(2));
        Assert.That(profile.Count, Is.EqualTo(13));
        Assert.Pass();
    }

    [Test]
    public void personal_test()
    {
        var text = "aabbbccccdde";
        var profile = HuffmanTree.Profile(text);
        Assert.That(profile['a'], Is.EqualTo(2));
        Assert.That(profile['b'], Is.EqualTo(3));
        Assert.That(profile['c'], Is.EqualTo(4));
        Assert.That(profile['d'], Is.EqualTo(2));
        Assert.That(profile['e'], Is.EqualTo(1));
        Assert.That(profile.Count, Is.EqualTo(5));
        Assert.Pass();
    }

    [Test]
    public void Test2_BuildTree()
    {
        var text = "aabbbccccdde";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        Assert.That(tree.Count, Is.EqualTo(12));
        Assert.That(tree.Left.Count, Is.EqualTo(5));
        Assert.That(tree.Left.Left.Count, Is.EqualTo(2));
        Assert.That(tree.Left.Left.Letter, Is.EqualTo('a'));
        Assert.That(tree.Left.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Count, Is.EqualTo(3));
        Assert.That(tree.Left.Right.Left.Count, Is.EqualTo(1));
        Assert.That(tree.Left.Right.Left.Letter, Is.EqualTo('e'));
        Assert.That(tree.Left.Right.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Right.Count, Is.EqualTo(2));
        Assert.That(tree.Left.Right.Right.Letter, Is.EqualTo('d'));
        Assert.That(tree.Left.Right.Right.Left, Is.EqualTo(null));
        Assert.That(tree.Left.Right.Right.Right, Is.EqualTo(null));
        Assert.That(tree.Right.Count, Is.EqualTo(7));
        Assert.That(tree.Right.Left.Count, Is.EqualTo(3));
        Assert.That(tree.Right.Left.Letter, Is.EqualTo('b'));
        Assert.That(tree.Right.Left.Left, Is.EqualTo(null));
        Assert.That(tree.Right.Left.Right, Is.EqualTo(null));
        Assert.That(tree.Right.Right.Count, Is.EqualTo(4));
        Assert.That(tree.Right.Right.Letter, Is.EqualTo('c'));
        Assert.That(tree.Right.Right.Left, Is.EqualTo(null));
        Assert.That(tree.Right.Right.Right, Is.EqualTo(null));

        Assert.Pass();
    }

    [Test]
    public void Test3_CreateEncodingMap()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        Assert.That(map['l'], Is.EqualTo("0000"));
        Assert.That(map['e'], Is.EqualTo("0001"));
        Assert.That(map['h'], Is.EqualTo("0010"));
        Assert.That(map['r'], Is.EqualTo("00110"));
        Assert.That(map['m'], Is.EqualTo("00111"));
        Assert.That(map['p'], Is.EqualTo("0100"));
        Assert.That(map['y'], Is.EqualTo("0101"));
        Assert.That(map['a'], Is.EqualTo("011"));
        Assert.That(map['s'], Is.EqualTo("1000"));
        Assert.That(map['t'], Is.EqualTo("1001"));
        Assert.That(map['n'], Is.EqualTo("101"));
        Assert.That(map['i'], Is.EqualTo("110"));
        Assert.That(map[' '], Is.EqualTo("111"));
        Assert.That(map.Count, Is.EqualTo(13));
        Assert.Pass();

    }
    
    [Test]
    public void Test4_Encode()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        var encoded = HuffmanTree.Encode(text, map);
        Assert.That(encoded, Is.EqualTo("10010010000111100110011110101111110101111100001000111101011111000100101101011000111001110111101010000010111111010111110010010000111101000000011110101"));
        Assert.Pass();

    }

    [Test]
    public void Test5_Decode()
    {
        var text = "the rain in spain stays mainly in the plain";
        var profile = HuffmanTree.Profile(text);
        var tree = HuffmanTree.BuildTree(profile);
        var map = HuffmanTree.CreateEncodingMap(tree);
        var encoded = HuffmanTree.Encode(text, map);
        Assert.That(encoded, Is.EqualTo("10010010000111100110011110101111110101111100001000111101011111000100101101011000111001110111101010000010111111010111110010010000111101000000011110101"));
        var decoded = HuffmanTree.Decode(encoded, tree);
        Assert.That(decoded, Is.EqualTo("the rain in spain stays mainly in the plain"));
        Assert.Pass();

    }
}

#pragma warning restore CS8602  // Dereference of a possibly null reference.
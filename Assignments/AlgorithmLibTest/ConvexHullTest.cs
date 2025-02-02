/*  CSE 381 - Convex Hull (Graham Scan) Test
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
public class ConvexHullTest
{

    [Test]
    public void Test1_ConvexOrientation()
    {
        var a = new ConvexHull.Point(0, 0);
        var b = new ConvexHull.Point(4, 0);
        var c = new ConvexHull.Point(3, 1);
        var result = ConvexHull.Orientation(a, b, c);
        Assert.That(result, Is.EqualTo(ConvexHull.Angle.Convex));
    }
    
    [Test]
    public void Test2_ConcaveOrientation()
    {
        var a = new ConvexHull.Point(4, 0);
        var b = new ConvexHull.Point(3, 1);
        var c = new ConvexHull.Point(8, 8);
        var result = ConvexHull.Orientation(a, b, c);
        Assert.That(result, Is.EqualTo(ConvexHull.Angle.Concave));
    }
    
    [Test]
    public void Test3_ColinearOrientation()
    {
        var a = new ConvexHull.Point(0, 0);
        var b = new ConvexHull.Point(1, 1);
        var c = new ConvexHull.Point(8, 8);
        var result = ConvexHull.Orientation(a, b, c);
        Assert.That(result, Is.EqualTo(ConvexHull.Angle.Colinear));
    }
    
    [Test]
    public void Test4_GetAngle()
    {
        var anchor = new ConvexHull.Point(1, 2);
        var p = new ConvexHull.Point(4, 7);
        var result = ConvexHull.GetAngle(anchor, p);
        Assert.That(result, Is.EqualTo(1.030).Within(0.001));
    }

    [Test]
    public void Test5_GetDistance()
    {
        var anchor = new ConvexHull.Point(1, 2);
        var p = new ConvexHull.Point(4, 7);
        var result = ConvexHull.GetDist(anchor, p);
        Assert.That(result, Is.EqualTo(5.831).Within(0.001));
    }
    
    [Test]
    public void Test6_TooFewPoints()
    {
        var points = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(4, 0),
        };
        var hull = ConvexHull.GenerateHull(points);
        
        Assert.That(hull.Count, Is.EqualTo(0));

        Assert.Pass();
    }
    
    [Test]
    public void Test7_CreateHull()
    {
        var points = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(4, 0),
            new(3, 1),
            new(1, 1),
            new(8, 8),
            new(3, 6),
            new(1, 4),
            new(1, 3),
            new(0, 4),
            new(0, 2),
            new(5.5, 7)
        };
        var hull = ConvexHull.GenerateHull(points);
        
        var expected = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(4, 0),
            new(8, 8),
            new(3, 6),
            new(0, 4),
            new(0, 0)
        };
        
        Assert.That(hull.Count, Is.EqualTo(expected.Count));

        for (var i = 0; i < hull.Count; i++)
        {
            Assert.That(hull[i].Equals(expected[i]), Is.True);
        }

        Assert.Pass();
    }
    
        public void Test8_AllCoLinear()
    {
        var points = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(1, 1),
            new(2, 2),
            new(3, 3),
            new(5, 4),
            new(6, 6),
        };
        var hull = ConvexHull.GenerateHull(points);
        
        Assert.That(hull.Count, Is.EqualTo(0));

        Assert.Pass();
    }

    [Test]
    public void Test9_AlmostCoLinear()
    {
        var points = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(1, 1),
            new(2, 2),
            new(3, 3),
            new(5, 4),
            new(6, 7),
        };
        var hull = ConvexHull.GenerateHull(points);
        
        var expected = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(5, 4),
            new(6, 7),
            new(0, 0)
        };
        
        Assert.That(hull.Count, Is.EqualTo(expected.Count));

        for (var i = 0; i < hull.Count; i++)
        {
            Assert.That(hull[i].Equals(expected[i]), Is.True);
        }

        Assert.Pass();
    }

    [Test]
    public void Test10_TooSmallToCreateHull()
    {
        var points = new List<ConvexHull.Point>()
        {
            new(0, 0),
            new(1, 1),
        };
        var hull = ConvexHull.GenerateHull(points);
        
        Assert.That(hull.Count, Is.EqualTo(0));

        Assert.Pass();
    } 
    
}
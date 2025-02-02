/*  CSE 381 - Bellman Ford Test
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
public class BellmanFordShortestPathTest
{
    
    [Test]
    public void Test1_NoNegativeCycle()
    {
        Graph g = new(5);
        g.SetLabel(0, "s");
        g.SetLabel(1, "t");
        g.SetLabel(2, "x");
        g.SetLabel(3, "y");
        g.SetLabel(4, "z");
        g.AddDirectedEdge(0, 1, 6);
        g.AddDirectedEdge(0, 3, 7);
        g.AddDirectedEdge(1, 2, 5);
        g.AddDirectedEdge(1, 3, 8);
        g.AddDirectedEdge(1, 4, -4);
        g.AddDirectedEdge(2, 1, -2);
        g.AddDirectedEdge(3, 2, -3);
        g.AddDirectedEdge(3, 4, 9);
        g.AddDirectedEdge(4, 0, 2);
        g.AddDirectedEdge(4, 2, 7);
        var (distance, pred) = BellmanFordShortestPath.ShortestPath(g, 0);
        Assert.That(distance[0], Is.EqualTo(0));
        Assert.That(distance[1], Is.EqualTo(2));
        Assert.That(distance[2], Is.EqualTo(4));
        Assert.That(distance[3], Is.EqualTo(7));
        Assert.That(distance[4], Is.EqualTo(-2));
        Assert.That(pred[0], Is.EqualTo(Graph.INF));
        Assert.That(pred[1], Is.EqualTo(2));
        Assert.That(pred[2], Is.EqualTo(3));
        Assert.That(pred[3], Is.EqualTo(0));
        Assert.That(pred[4], Is.EqualTo(1));
    }
    
    [Test]
    public void Test2_NegativeCycle()
    {
        Graph g = new Graph(5);
        g.SetLabel(0, "s");
        g.SetLabel(1, "t");
        g.SetLabel(2, "x");
        g.SetLabel(3, "y");
        g.SetLabel(4, "z");
        g.AddDirectedEdge(0, 1, 6);
        g.AddDirectedEdge(0, 3, 7);
        g.AddDirectedEdge(1, 2, 5);
        g.AddDirectedEdge(1, 3, -1);
        g.AddDirectedEdge(1, 4, -4);
        g.AddDirectedEdge(2, 1, -2);
        g.AddDirectedEdge(3, 2, -3);
        g.AddDirectedEdge(3, 4, 9);
        g.AddDirectedEdge(4, 0, 2);
        g.AddDirectedEdge(4, 2, 7);
        var (distance, pred) = BellmanFordShortestPath.ShortestPath(g, 0);
        if (distance.Count == 0) {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }        
       
    }
}
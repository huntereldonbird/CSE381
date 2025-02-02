/*  CSE 381 - DAG Shortest Path Test
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
public class DAGShortestPathTest
{
    [Test]
    public void Test1_TopoSort()
    {
        Graph g = new(9);
        g.SetLabel(0, "A");
        g.SetLabel(1, "B");
        g.SetLabel(2, "C");
        g.SetLabel(3, "D");
        g.SetLabel(4, "E");
        g.SetLabel(5, "F");
        g.SetLabel(6, "G");
        g.SetLabel(7, "H");
        g.SetLabel(8, "I");
        g.AddDirectedEdge(0, 3, 3);
        g.AddDirectedEdge(1, 3, 2);
        g.AddDirectedEdge(2, 5,5);
        g.AddDirectedEdge(3, 6, 9);
        g.AddDirectedEdge(5,6, 3);
        g.AddDirectedEdge(4, 8, 7);
        g.AddDirectedEdge(6, 8, 7);
        g.AddDirectedEdge(7, 8,5 );
        var result = DAGShortestPath.Sort(g);
        
        Assert.That(result[0], Is.EqualTo(7));
        Assert.That(result[1], Is.EqualTo(4));
        Assert.That(result[2], Is.EqualTo(2));
        Assert.That(result[3], Is.EqualTo(5));
        Assert.That(result[4], Is.EqualTo(1));
        Assert.That(result[5], Is.EqualTo(0));
        Assert.That(result[6], Is.EqualTo(3));
        Assert.That(result[7], Is.EqualTo(6));
        Assert.That(result[8], Is.EqualTo(8));

        Assert.Pass();
    }
    
    [Test]
    public void Test2_DAG1()
    {
        Graph g = new(9);
        g.SetLabel(0, "A");
        g.SetLabel(1, "B");
        g.SetLabel(2, "C");
        g.SetLabel(3, "D");
        g.SetLabel(4, "E");
        g.SetLabel(5, "F");
        g.SetLabel(6, "G");
        g.SetLabel(7, "H");
        g.SetLabel(8, "I");
        g.AddDirectedEdge(0, 3, 3);
        g.AddDirectedEdge(1, 3, 2);
        g.AddDirectedEdge(2, 5,5);
        g.AddDirectedEdge(3, 6, 9);
        g.AddDirectedEdge(5,6, 3);
        g.AddDirectedEdge(4, 8, 7);
        g.AddDirectedEdge(6, 8, 7);
        g.AddDirectedEdge(7, 8,5 );
        var (distance, pred) = DAGShortestPath.ShortestPath(g, 2);
        Assert.That(distance[0], Is.EqualTo(Graph.INF));
        Assert.That(distance[1], Is.EqualTo(Graph.INF));
        Assert.That(distance[2], Is.EqualTo(0));
        Assert.That(distance[3], Is.EqualTo(Graph.INF));
        Assert.That(distance[4], Is.EqualTo(Graph.INF));
        Assert.That(distance[5], Is.EqualTo(5));
        Assert.That(distance[6], Is.EqualTo(8));
        Assert.That(distance[7], Is.EqualTo(Graph.INF));
        Assert.That(distance[8], Is.EqualTo(15));
        Assert.That(pred[0], Is.EqualTo(Graph.INF));
        Assert.That(pred[1], Is.EqualTo(Graph.INF));
        Assert.That(pred[2], Is.EqualTo(Graph.INF));
        Assert.That(pred[3], Is.EqualTo(Graph.INF));
        Assert.That(pred[4], Is.EqualTo(Graph.INF));
        Assert.That(pred[5], Is.EqualTo(2));
        Assert.That(pred[6], Is.EqualTo(5));
        Assert.That(pred[7], Is.EqualTo(Graph.INF));
        Assert.That(pred[8], Is.EqualTo(6));
        Assert.Pass();
    }
    
    [Test]
    public void Test3_DAG2()
    {
        Graph g = new(6);
        g.SetLabel(0, "r");
        g.SetLabel(1, "s");
        g.SetLabel(2, "t");
        g.SetLabel(3, "x");
        g.SetLabel(4, "y");
        g.SetLabel(5, "z");
        g.AddDirectedEdge(0,1, 5);
        g.AddDirectedEdge(0, 2, 3);
        g.AddDirectedEdge(1, 2, 2);
        g.AddDirectedEdge(1, 3, 6);
        g.AddDirectedEdge(2, 3, 7);
        g.AddDirectedEdge(2, 4, 4);
        g.AddDirectedEdge(2, 5,2);
        g.AddDirectedEdge(3, 4,-1);
        g.AddDirectedEdge(3, 5, 1);
        g.AddDirectedEdge(4, 5, -2);
        var (distance, pred) = DAGShortestPath.ShortestPath(g, 1);
        Assert.That(distance[0], Is.EqualTo(Graph.INF));
        Assert.That(distance[1], Is.EqualTo(0));
        Assert.That(distance[2], Is.EqualTo(2));
        Assert.That(distance[3], Is.EqualTo(6));
        Assert.That(distance[4], Is.EqualTo(5));
        Assert.That(distance[5], Is.EqualTo(3));
        Assert.That(pred[0], Is.EqualTo(Graph.INF));
        Assert.That(pred[1], Is.EqualTo(Graph.INF));
        Assert.That(pred[2], Is.EqualTo(1));
        Assert.That(pred[3], Is.EqualTo(1));
        Assert.That(pred[4], Is.EqualTo(3));
        Assert.That(pred[5], Is.EqualTo(4));
        Assert.Pass();
    }
}
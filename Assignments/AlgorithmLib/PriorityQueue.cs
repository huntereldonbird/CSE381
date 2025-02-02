/* CSE 381 - Priority Queue
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Do not modify this file.  You will use this in your code.
*/

namespace AlgorithmLib;


public class PriorityQueue<T> where T : notnull
{
    // Each node in the priority queue contains a value
    // and a priority (number)
    private class PqNode
    {
        public T Value { get; init; } = default!;
        public int Priority { get; set; }
    }
    
    // Will represent the priority queue as an array/list
    private readonly List<PqNode> _heap = new();
    
    // Quick lookup to find a node based on the value 
    private readonly Dictionary<T,int> _lookup = new(); 

    // Functions to find parent, children, and leaf status when using an array for the heap
    private static int Parent(int index)
    {
        return (index - 1) / 2;
    }

    private bool IsLeaf(int index)
    {
        return index >= _heap.Count / 2;
    }

    private static int Left(int index)
    {
        return 2 * index + 1;
    }

    private static int Right(int index)
    {
        return 2 * index + 2;
    }
    
    // Start at node at index curr and swap up as needed
    private void BubbleUp(int curr)
    {
        while (curr > 0)
        {
            var parent = Parent(curr);
            if (_heap[parent].Priority.CompareTo(_heap[curr].Priority) > 0) 
            {
                // Need to swap
                (_heap[parent], _heap[curr]) = (_heap[curr], _heap[parent]);
                // Update the lookup map with new array indices
                _lookup[_heap[curr].Value] = curr;
                _lookup[_heap[parent].Value] = parent;
            }
            curr = parent;
        }
    }

    // Start at node at index curr and swap down as needed
    private void BubbleDown(int curr)
    {
        while (!IsLeaf(curr))
        {
            var left = Left(curr);
            var right = Right(curr);
            // If there is no right or if left is smaller than right, then go left
            if (right >= _heap.Count || _heap[left].Priority.CompareTo(_heap[right].Priority) <= 0) 
            {
                if (_heap[curr].Priority.CompareTo(_heap[left].Priority) > 0)
                {
                    // Swap and update lookup map with new indices
                    (_heap[curr], _heap[left]) = (_heap[left], _heap[curr]);
                    _lookup[_heap[curr].Value] = curr;
                    _lookup[_heap[left].Value] = left;
                }

                curr = left;
            }
            // Go right otherwise
            else 
            {
                if (_heap[curr].Priority.CompareTo(_heap[right].Priority) > 0)
                {
                    // Swap and update lookup map with new indices
                    (_heap[curr], _heap[right]) = (_heap[right], _heap[curr]);
                    _lookup[_heap[curr].Value] = curr;
                    _lookup[_heap[right].Value] = right;
                }

                curr = right;
            }
        }
    }

    // Decrease the priority of a node and update the queue
    public void DecreasePriority(T value, int priority)
    {
        // Verify the value requested actually exists.
        if (!_lookup.ContainsKey(value)) {
            return;
        }

        // Get location of value in the array 
        var curr = _lookup[value];
        // Change the priority of the value
        _heap[curr].Priority = priority;
        // Priority is lower so bubble-up curr
        BubbleUp(curr);
    }

    // Add a new value with a priority to the queue
    public void Enqueue(T value, int priority)
    {
        // Create the new node
        var newNode = new PqNode { Priority = priority, Value = value };
        // Add it to the end of the array
        _heap.Add(newNode);
        // Add link in the lookup map
        var curr = _heap.Count - 1;
        _lookup[value] = curr;
        // Bubble-up curr
        BubbleUp(curr);

    }

    // Remove the smallest value (at index 0) of the queue.
    public T Dequeue()
    {
        // Special case if queue is empty
        if (_heap.Count == 0)
            throw new Exception("Priority Queue was empty");
        
        // Swap the first (the one to be removed) with the last
        var result = _heap[0];
        var last = _heap[^1];
        _heap[0] = last;
        // Update the lookup map for the one we moved to the top
        _lookup[_heap[0].Value] = 0;
        // Update the array and lookup map for the one we moved to the end
        _heap.RemoveAt(_heap.Count-1);
        _lookup.Remove(result.Value);
        // Bubble the item at the root down to the appropriate place
        BubbleDown(0);
        
        // Return the value removed
        return result.Value;
    }

    // Get the number of nodes in the priority queue
    public int Size()
    {
        return _heap.Count;
    }

}
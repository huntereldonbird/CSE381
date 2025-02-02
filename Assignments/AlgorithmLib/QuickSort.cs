/*  CSE 381 - Quick Sort
 *  (c) BYU-Idaho - It is an honor code violation to post this
 *  file completed in a public file sharing site. W5.
 *
 *  Instructions: Implement the Partition and _Sort functions per the instructions
 *  in the comments.  Run all tests in QuickSortTest.cs to verify your code.
 */
namespace AlgorithmLib;

public static class QuickSort
{


    /* Use Quick Sort to sort a list of values in place
     *
     *  Inputs:
     *     data - list of values
     *  Outputs:
     *     none
     */
    public static void Sort<T>(List<T> data) where T : IComparable<T>
    {
        // Start the recursion with the entire list
        _Sort(data, 0, data.Count - 1);
    }
    
    /* Recursively use quick sort to sort a sublist
     * defined by first and last.
     *
     *  Inputs:
     *     data - list of values
     *     first - the start of the sublist
     *     last - the end of the sublist
     *  Outputs:
     *     None
     */
    public static void _Sort<T>(List<T> data, int first, int last) where T : IComparable<T>
    {

        if (first < last) {


            int p = Partition(data, first, last);


            _Sort(data, first, p-1);
            _Sort(data, p + 1, last);

        }  



    }
    
    /* Partition a sublist by finding where a pivot belongs when sorted.  All
     * values less or equal to the pivot must be on the left hand side and
     * all values greater must be on the right hand size of the pivot.
     * In this implementation, do not select a random pivot.  Select the
     * last value in the sublist to always be your pivot.
     *
     *  Inputs:
     *     data - list of values
     *     first - the start of the sublist
     *     last - the end of the sublist
     *  Outputs:
     *     The index of where the pivot was moved
     */
    public static int Partition<T>(List<T> data, int first, int last) where T : IComparable<T> {


        var pivot = data[last];
        int l = first - 1;

        for (int i = first; i <= last - 1; i++) {

            if (data[i].CompareTo(pivot) <= 0) {

                l++;
                (data[l], data[i]) = (data[i], data[l]);

            }

        }

        (data[l+1], data[last]) = (data[last], data[l+1]);

        return l + 1;
    }
}
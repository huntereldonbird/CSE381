/* CSE 381 - Merge Sort
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Merge and _Sort functions per the instructions
*  in the comments.  Run all tests in MergeSortTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class MergeSort
{
    /* Use Merge Sort to sort a list of values in place
     *
     *  Inputs:
     *     data - list of values
     *  Outputs:
     *     none
     */
    public static void Sort<T>(List<T> data) where T : IComparable<T> 
    {
        // Start the recursive process with the whole list
        _Sort(data, 0, data.Count-1);
    }

    /* Recursively use merge sort to sort a sublist
     * defined by first and last.
     * 
     *  Inputs:
     *     data - list of values
     *     first - the start of the sublist
     *     last - the end of the sublist
     *  Outputs:
     *     None
     */

    // just "recersivly" sorts and breaks down the funciton into 2
    public static void _Sort<T>(List<T> data, int first, int last) where T : IComparable<T>
    {

        if (first < last)
        {
            int middle = (first + last) / 2;

            // Recursively sort both halves
            _Sort(data, first, middle);
            _Sort(data, middle + 1, last);

            // Merge the sorted halves
            Merge(data, first, middle, last);
        }

    }
    
    /* Merge two sorted list which are adjacent to each other back into
     * the same list.
     *
     *  Inputs:
     *     data - list of values
     *     first - the start of the first sorted sublist
     *     mid - the end of the first sorted sublist (second sublist starts after)
     *     last - the end of the second sorted sublist
     *  Outputs:
     *     None
     */


    // Merges "two" lists together given the numbers of lists.
    public static void Merge<T>(List<T> data, int first, int mid, int last) where T : IComparable<T> {

        int leftSize = mid - first + 1;
        int rightSize = last - mid;

        // Create temporary arrays for both halves
        List<T> leftHalf = new List<T>();
        List<T> rightHalf = new List<T>();

        // Copy data to temporary arrays
        for (int i = 0; i < leftSize; i++)
            leftHalf.Add(data[first + i]);

        for (int i = 0; i < rightSize; i++)
            rightHalf.Add(data[mid + 1 + i]);

        int leftIndex = 0;
        int rightIndex = 0;
        int currentIndex = first;

        // Merge the temporary arrays back into data
        while (leftIndex < leftSize && rightIndex < rightSize) {


            if (leftHalf[leftIndex].CompareTo(rightHalf[rightIndex]) <= 0) {



                // if the left half is lesser
                data[currentIndex] = leftHalf[leftIndex];
                leftIndex++;
            }
            else {
                // if the right half is lesser
                data[currentIndex] = rightHalf[rightIndex];
                rightIndex++;

            }
            currentIndex++;
        }

        // just incraments the rest of the functions if one of them runs out.
        while (leftIndex < leftSize) {

            data[currentIndex] = leftHalf[leftIndex];
            leftIndex++;
            currentIndex++;

        }
        while (rightIndex < rightSize) {

            data[currentIndex] = rightHalf[rightIndex];
            rightIndex++;
            currentIndex++;

        }

    }
}


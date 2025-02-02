/* CSE 381 - BetterLinearSerach
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Search function per the instructions
*  in the comments.  Run all tests in BetterLinearSearchTest.cs to verify your code.
*/

namespace AlgorithmLib;

using System;
using System.Collections.Generic;

public static class BetterLinearSearch
{

    // this function iterates over all elements linearly and then returns the first result that is equivalent

    public static int Search<T>(List<T> data, T target) where T : IComparable<T>
    {
        for (int i = 0; i < data.Count; i++) {

            if (data[i].Equals(target)) {
                return i;
            }
        }
        return -1;
    }
}
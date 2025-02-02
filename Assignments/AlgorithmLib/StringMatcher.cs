/* CSE 381 - String Matcher
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Match and BuildTable functions per the instructions
*  in the comments.  Run all tests in StringMatcherTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class StringMatcher
{
    /* Find all matches of the pattern in the string of text given a list
     * of all valid input characters.  This function needs to build Finite
     * State Machine table by calling BuildTable.
     *
     *  Inputs:
     *     text - string to search for pattern
     *     pattern - string to search
     *     inputs - valid characters using in the text and pattern
     *  Outputs:
     *     list of indices where the pattern matched (last char of pattern match)
     */
    public static List<int> Match(string text,  string pattern, List<char> inputs)
    {
        return new List<int>();
    }

    /* Build the Finite State Machine table for the pattern and list of valid
     * inputs provided.
     *
     *  Inputs:
     *     pattern - string to match
     *     inputs - valid list of characters that could be seen
     *  Outputs:
     *     Finite State Machine defined by a list of dictionaries.  Each index
     *     in the list represents a state in the FSM (index 0 is first).  The
     *     dictionary shows the next state to goto for each of the valid
     *     inputs that can occur.
     */
    public static List<Dictionary<char, int>> BuildTable(string pattern, List<char> inputs)
    {
        return new List<Dictionary<char, int>>();
    }
}
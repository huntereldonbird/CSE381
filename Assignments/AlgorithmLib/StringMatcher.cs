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
    public static List<int> Match(string text,  string pattern, List<char> inputs) {

        // the book was really dense so I watched a video about a similar algorithm on youtube.

        List<int> matched = new List<int>();
        List<Dictionary<char, int>> builtalbe = BuildTable(pattern, inputs);

        int state = 0; // this is that counting that you were talking about in class...


        // so in short, we are couting up by each char, and if we find a matching char in our pattern we then incremenet the counter.
        // then if the counter is the same size as the pattern length then we know we have found a solution, then we set it to a reset state

        for (int i = 0; i < text.Length; i++) {

            char ch = text[i];

            if (builtalbe[state].ContainsKey(ch)) {
                state = builtalbe[state][ch];
            }
            else {

                // if we dont find it the counter needs to be reset.
                state = 0;

                if (builtalbe[state].ContainsKey(ch)) {
                    state = builtalbe[state][ch];
                }
            }

            if (state == pattern.Length) {

                // if we have a completed word, append it to the output list

                matched.Add(i);

                if (builtalbe.Count > pattern.Length && builtalbe[pattern.Length].ContainsKey(ch)) {

                    // basically, if there is still a chance that we could find another, we need to keep looking...

                    state = builtalbe[pattern.Length][ch];
                }
                else {

                    // ... if not, we need to restart completly
                    state = 0;
                }
            }


        }

        return matched;
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
    public static List<Dictionary<char, int>> BuildTable(string pattern, List<char> inputs) {


        // start the fms table
        List<Dictionary<char, int>> fsm_talbe = new List<Dictionary<char, int>>();


        // create the entries and keys
        for (int i = 0; i <= pattern.Length; i++) {

            fsm_talbe.Add(new Dictionary<char, int>());

        }


        // this is basically a 3d array, but with a dictionary so that we can go by char instead of by ints

        // IM SO MAD, I HAD IT AS < FOR SO LONG AND IT TOOK ME SO LONG TO FIGURE IT OUT!!!!
        for (int i = 0; i <= pattern.Length; i++) {



            foreach (char _this in inputs) {

                string ard = pattern.Substring(0, i) + _this; // This line I had to get help from the internet... I found that this was the easiest way to figure this out. ard means nothing i just pressed keys on keybaord
                int next = 0;
                for (int j = Math.Min(pattern.Length, ard.Length); j > 0; j--) {

                    if (pattern.Substring(0, j) == ard.Substring(ard.Length - j)) {
                        next = j;
                        break;
                    }
                }

                // add it all to the table

                fsm_talbe[i][_this] = next;

            }

        }

        return fsm_talbe;






    }
}
/* CSE 381 - Huffman Tree
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. W5.
*
*  Instructions: Implement the Profile, BuildTree, _CreateEncodingMap,
*  Encode, and Decode function per the instructions in the comments.  
*  Run all tests in HuffmanTreeTest.cs to verify your code.
*/

namespace AlgorithmLib;

public static class HuffmanTree
{
    /* Represent the nodes in the Huffman Tree */
    public class Node
    {
        // Letter represented by the node.  Can be blank.
        public char Letter { get; set; }
        
        // Frequency of letters in the sub-tree beginning with this node
        public int Count { get; set; }
        
        // Left and Right sub-trees (can be Null)
        public Node? Left;
        public Node? Right;
    }

    /* Create a profile showing the frequency of all letters
     * from a string of text.
     *
     *  Inputs:
     *     text - Source for the profile
     *  Outputs:
     *     Dictionary where key is a character and value is the frequency count
     *     from the text.
     */
    public static Dictionary<char,int> Profile(String text)
    {
        Dictionary<char, int> profile = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++) {

            if (profile.ContainsKey(text[i])) {
                profile[text[i]]++;
            }
            else {
                profile.Add(text[i], 1);
            }
        }
        return profile;
    }

    /* Create a huffman tree for all letters in the profile.  Use
     * a Priority Queue (code already provided) in your implementation.
     *
     *  Inputs:
     *     profile - Previously generated profile dictionary
     *  Outputs:
     *     The root node of a huffman tree
     */
    public static Node BuildTree(Dictionary<char, int> profile) {


        // i origionally tried to use the profiles but that didnt work, so I created the nodes beforehand
        List<Node> nodes = new List<Node>();

        foreach (var n in profile) {
            nodes.Add(new Node {
                Letter = n.Key,
                Count = n.Value,
                Left = null,
                Right = null
            });
        }


        while (nodes.Count > 1) {

            nodes = nodes.OrderBy(n => n.Count).ThenByDescending(n => n.Letter).ToList();

            Node left = nodes[0];
            Node right = nodes[1];
            nodes.RemoveAt(0);
            nodes.RemoveAt(0);


            Node new_node = new Node {
                Letter = '\0',
                Count = left.Count + right.Count,
                Left = left,
                Right = right
            };
            nodes.Add(new_node);
        }
        return nodes[0];
    }

    /* Create an encoding map from the huffman tree
     *
     *  Inputs:
     *     root - Root node of the Huffman Tree
     *  Outputs:
     *     A dictionary where key is the letter and value is the
     *     huffman code.
     */
    public static Dictionary<char, string> CreateEncodingMap(Node root)
    {
        Dictionary<char, string> m = new Dictionary<char, string>();
        _CreateEncodingMap(root, "", m);
        return m;
    }

    /* Recursively visit each node in the Huffman Tree
     * looking for leaf nodes which contain letters.  Keep
     * track of the huffman code by adding 0 when going left
     * and 1 when going right
     *
     *  Inputs:
     *     node - Current node we are on
     *     code - Current code created
     *     map - Encoding Map being populated
     *  Outputs:
     *     none
     */
    public static void _CreateEncodingMap(Node node, string code, Dictionary<char, string> map)
    {

        if (node.Left == null && node.Right == null && node.Letter == '\0') {
            map[node.Letter] = code;
            return;

        }

        if (node.Left != null) {
            _CreateEncodingMap(node.Left, code + "0", map);
        }
        if (node.Right != null) {
            _CreateEncodingMap(node.Right, code + "1", map);
        }


    }

    /* Encode a string with the encoding map.
     *
     *  Inputs:
     *     text - String to encode
     *     map - Encoding Map previously created
     *  Outputs:
     *     A string of huffman codes (1's and 0's) representing the
     *     encoding of the text.
     */
    public static string Encode(string text, Dictionary<char, string> map)
    {
        string result = "";

        for (int i = 0; i < text.Length; i++) {
            result += map[text[i]];
        }

        return result;
    }

    /* Decode a string with the huffman tree
     *
     *  Inputs:
     *     text - String to decode
     *     root - Root node of the previously created huffman tree
     *  Outputs:
     *     decoded text
     */
    public static string Decode(string text, Node tree)
    {
        return "";
    }
}
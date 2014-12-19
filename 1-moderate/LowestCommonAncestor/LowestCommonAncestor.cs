using System;
using System.IO;
using System.Linq;

class LowestCommonAncestor
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                int[] values = line.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                Console.WriteLine(LCA(root, values[0], values[1]).Data);

                // end of code
            }

        Console.ReadLine();
    }

    // hardcoded binary tree
    //    30
    //    |
    //  ____
    //  |   |
    //  8   52
    //  |
    //____
    //|   |
    //3  20
    //    |
    //   ____
    //  |   |
    //  10 29
    static Node a = new Node(10, null, null);
    static Node b = new Node(29, null, null);
    static Node ab = new Node(20, a, b);
    static Node c = new Node(3, null, null);
    static Node cab = new Node(8, c, ab);
    static Node d = new Node(52, null, null);
    static Node root = new Node(30, cab, d);

    public class Node
    {
        public int Data { get; set; }
        public Node RightChild { get; set; }
        public Node LeftChild { get; set; }

        public Node(int data, Node a, Node b)
        {
            Data = data;
            LeftChild = a;
            RightChild = b;
        }
    }

    public static Node LCA(Node root, int value1, int value2)
    {
        if (root == null)
            return null;

        if (root.Data > value1 && root.Data > value2)
            return LCA(root.LeftChild, value1, value2);
        else if (root.Data < value1 && root.Data < value2)
            return LCA(root.RightChild, value1, value2);
        else
            return root;
    }
}
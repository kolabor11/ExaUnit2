using System;
using System.Collections.Generic;

class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

class Program
{
    static void Main()
    {
        Node rootNode = CreateTree(); 

        int sum = CalculateSum(rootNode);
        int deepestLevel = FindDeepestLevel(rootNode);
        int nodeCount = CountNodes(rootNode);

        Console.WriteLine($"Sum of the full structure: {sum}");
        Console.WriteLine($"Deepest level of the structure: {deepestLevel}");
        Console.WriteLine($"Number of nodes: {nodeCount}");
    }

    static Node CreateTree()
    {


        Node leaf241 = new Node { Value = 241 };
        Node leaf571 = new Node { Value = 571, Left = leaf241 };
        Node leaf558 = new Node { Value = 558, Left = leaf571 };
        Node leaf269 = new Node { Value = 269, Left = leaf558 };

        Node leaf653 = new Node { Value = 653, Left = leaf269 };

        Node leaf879 = new Node { Value = 879 };
        Node leaf330 = new Node { Value = 330, Left = new Node { Value = 752 }, Right = leaf879 };
        Node leaf328 = new Node { Value = 328 };
        Node leaf278 = new Node { Value = 278 };
        Node leaf983 = new Node { Value = 983 };
        Node leaf924 = new Node { Value = 924, Left = leaf269 };
        Node leaf912 = new Node { Value = 912, Left = leaf983, Right = new Node { Value = 438 } };

        Node leaf364 = new Node { Value = 364 };
        Node leaf131 = new Node { Value = 131 };
        Node leaf125 = new Node { Value = 125 };
        Node leaf895 = new Node { Value = 895 };
        Node leaf910 = new Node { Value = 910, Left = new Node { Value = 12 } };
        Node leaf86 = new Node { Value = 86 };
        Node leaf429 = new Node { Value = 429 };
        Node leaf545 = new Node { Value = 545, Left = new Node { Value = 267 } };

        Node leaf168 = new Node { Value = 168, Left = leaf732, Right = leaf168 };

        Node leaf281 = new Node { Value = 281, Right = leaf168 };

        return leaf281; 
    }

    static int CalculateSum(Node node)
    {
        if (node == null)
            return 0;

        return node.Value + CalculateSum(node.Left) + CalculateSum(node.Right);
    }

    static int FindDeepestLevel(Node node)
    {
        if (node == null)
            return 0;

        int leftDepth = FindDeepestLevel(node.Left);
        int rightDepth = FindDeepestLevel(node.Right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    static int CountNodes(Node node)
    {
        if (node == null)
            return 0;

        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }
}

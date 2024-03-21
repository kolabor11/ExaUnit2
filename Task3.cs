using System;
using Newtonsoft.Json.Linq;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public static TreeNode ParseJson(string json)
    {
        return JObject.Parse(json).ToObject<TreeNode>();
    }

    public int CalculateSum()
    {
        int sum = Value;

        if (Left != null)
            sum += Left.CalculateSum();
        
        if (Right != null)
            sum += Right.CalculateSum();

        return sum;
    }

    public int FindDeepestLevel()
    {
        if (Left == null && Right == null)
            return 0;

        int leftDepth = Left != null ? Left.FindDeepestLevel() + 1 : 0;
        int rightDepth = Right != null ? Right.FindDeepestLevel() + 1 : 0;

        return Math.Max(leftDepth, rightDepth);
    }

    public int CountNodes()
    {
        int count = 1;

        if (Left != null)
            count += Left.CountNodes();
        
        if (Right != null)
            count += Right.CountNodes();

        return count;
    }
}
using System;
using System.Diagnostics;
using System.Text;

public class BinaryTree
{
    TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    public void AddValue(int value)
    {
        if (root == null)
            root = new TreeNode(value);
        else
            root.AddValue(value);
    }

    public bool ContainsValue(int value)
    {
        if (root == null) return false;
        return root.ContainsValue(value);
    }

    public int CalculateSum()
    {
        if (root == null) return 0;
        return root.CalculateSum();
    }

    public int GetDepth()
    {
        if (root == null) return 0;
        return root.GetDepth();
    }

    public void DeleteValue(int value)
    {
        root?.DeleteValue(value);
    }

    public override string ToString()
    {
        if (root == null) return "";
        return root.ToString();
    }
}

internal class TreeNode
{
    internal int _value;
    TreeNode left;
    TreeNode right;
    bool isDeleted;

    internal TreeNode(int value)
    {
        _value = value;
        left = null;
        right = null;
        isDeleted = false;
    }

    internal void AddValue(int value)
    {
        if (value < _value)
        {
            if (left == null)
                left = new TreeNode(value);
            else
                left.AddValue(value);
        }
        else
        {
            if (right == null)
                right = new TreeNode(value);
            else
                right.AddValue(value);
        }
    }

    internal bool ContainsValue(int value)
    {
        if (value == _value && !isDeleted) return true;
        if (value < _value) return left != null && left.ContainsValue(value);
        return right != null && right.ContainsValue(value);
    }

    internal int CalculateSum()
    {
        int sum = isDeleted ? 0 : _value;
        if (left != null) sum += left.CalculateSum();
        if (right != null) sum += right.CalculateSum();
        return sum;
    }

    internal int GetDepth()
    {
        int leftDepth = left?.GetDepth() ?? 0;
        int rightDepth = right?.GetDepth() ?? 0;
        return 1 + Math.Max(leftDepth, rightDepth);
    }

    internal void DeleteValue(int value)
    {
        if (value == _value)
        {
            isDeleted = true;
            return;
        }
        if (value < _value) left?.DeleteValue(value);
        else right?.DeleteValue(value);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (left != null) sb.Append(left.ToString());
        if (!isDeleted) sb.Append(_value + " ");
        if (right != null) sb.Append(right.ToString());
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        tree.AddValue(10);
        tree.AddValue(5);
        tree.AddValue(15);
        tree.AddValue(3);
        tree.AddValue(7);

        Debug.Assert(tree.ContainsValue(10));
        Debug.Assert(tree.ContainsValue(5));
        Debug.Assert(!tree.ContainsValue(99));

        Debug.Assert(tree.CalculateSum() == 40);
        Debug.Assert(tree.GetDepth() == 3);

        tree.DeleteValue(5);
        Debug.Assert(!tree.ContainsValue(5));

        Console.WriteLine(tree.ToString());
    }
}
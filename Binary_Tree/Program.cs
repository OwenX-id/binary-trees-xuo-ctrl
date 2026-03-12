public class BinaryTree
{
    TreeNode _root;

    public BinaryTree()
    {
        _root = null;
    }
}

internal class TreeNode
{
    int _value;
    TreeNode _left;
    TreeNode _right;

    internal TreeNode(int v)
    {
        _value = v;
        _left = null;
        _right = null;
    }
}



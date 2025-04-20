namespace algos.BinarySearch;

internal static class BinarySearchTreeNodeExtension
{
    public static BinarySearchTreeNode FindMin(this BinarySearchTreeNode subtree) => subtree.FindMin(null, out _);
    public static BinarySearchTreeNode FindMin(this BinarySearchTreeNode subtree, BinarySearchTreeNode? parentOfSubtree, out BinarySearchTreeNode? parentOfMin)
    {
        parentOfMin = parentOfSubtree;
        BinarySearchTreeNode left = subtree;

        while (left.Left is not null)
        {
            parentOfMin = left;
            left = left.Left;
        }

        return left;
    }

    public static BinarySearchTreeNode FindMax(this BinarySearchTreeNode subtree) => subtree.FindMax(null, out _);

    public static BinarySearchTreeNode FindMax(this BinarySearchTreeNode subtree, BinarySearchTreeNode? parentOfSubtree, out BinarySearchTreeNode? parentOfMax)
    {
        parentOfMax = parentOfSubtree;
        BinarySearchTreeNode right = subtree;

        while (right.Right is not null)
        {
            parentOfMax = right;
            right = right.Right;
        }

        return right;
    }

    public static void TraverseForward(this BinarySearchTreeNode subtree, List<BinarySearchTreeNode> nodes)
    {
        subtree.Left?.TraverseForward(nodes);
        nodes.Add(subtree);
        subtree.Right?.TraverseForward(nodes);
    }

    public static void TraverseBackward(this BinarySearchTreeNode subtree, List<BinarySearchTreeNode> nodes)
    {
        subtree.Right?.TraverseBackward(nodes);
        nodes.Add(subtree);
        subtree.Left?.TraverseBackward(nodes);
    }

    public static BinarySearchTreeNode? Find(this BinarySearchTreeNode subtree, int key, BinarySearchTreeNode? parentOfSubtree, out BinarySearchTreeNode? parentOfFound)
    {
        if (subtree.Left is not null && (key < subtree.Key))
        {
            return Find(subtree.Left, key, subtree, out parentOfFound);
        }

        if (subtree.Right is not null && (key > subtree.Key))
        {
            return Find(subtree.Right, key, subtree, out parentOfFound);
        }

        if (key == subtree.Key)
        {
            parentOfFound = parentOfSubtree;
            return subtree;
        }

        return parentOfFound = null;
    }
}

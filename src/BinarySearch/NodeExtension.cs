namespace algos.BinarySearch;

internal static class NodeExtension
{
    public static Node FindMin(this Node subtree) => subtree.FindMin(null, out _);
    public static Node FindMin(this Node subtree, Node? parentOfSubtree, out Node? parentOfMin)
    {
        parentOfMin = parentOfSubtree;
        Node left = subtree;

        while (left.Left is not null)
        {
            parentOfMin = left;
            left = left.Left;
        }

        return left;
    }

    public static Node FindMax(this Node subtree) => subtree.FindMax(null, out _);

    public static Node FindMax(this Node subtree, Node? parentOfSubtree, out Node? parentOfMax)
    {
        parentOfMax = parentOfSubtree;
        Node right = subtree;

        while (right.Right is not null)
        {
            parentOfMax = right;
            right = right.Right;
        }

        return right;
    }

    public static void TraverseForward(this Node subtree, List<Node> nodes)
    {
        subtree.Left?.TraverseForward(nodes);
        nodes.Add(subtree);
        subtree.Right?.TraverseForward(nodes);
    }

    public static void TraverseBackward(this Node subtree, List<Node> nodes)
    {
        subtree.Right?.TraverseBackward(nodes);
        nodes.Add(subtree);
        subtree.Left?.TraverseBackward(nodes);
    }

    public static Node? Find(this Node subtree, int key, Node? parentOfSubtree, out Node? parentOfFound)
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

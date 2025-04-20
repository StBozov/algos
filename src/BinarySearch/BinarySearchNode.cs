using System.Collections;

namespace algos.BinarySearch;

internal class BinarySearchTreeNode(int key) : IEnumerable<int>
{
    public int Key { get; } = key;
    public BinarySearchTreeNode? Left { get; private set; }
    public BinarySearchTreeNode? Right { get; private set; }

    public bool HasChildren => Left is not null && Right is not null;
    public bool HasChild => Left is not null || Right is not null;
    public BinarySearchTreeNode Min => this.FindMin();
    public BinarySearchTreeNode Max => this.FindMax();

    public int Count
    {
        get
        {
            int count = 1;

            if (Right is not null)
            {
                count += Right.Count;
            }

            if (Left is not null)
            {
                count += Left.Count;
            }

            return count;
        }
    }

    public bool Insert(int key)
    {
        if (key < Key)
        {
            if (Left is not null)
            {
                return Left.Insert(key);
            }

            Left = new BinarySearchTreeNode(key);
            return true;
        }
        else if (key > Key)
        {
            if (Right is not null)
            {
                return Right.Insert(key);
            }

            Right = new BinarySearchTreeNode(key);
            return true;
        }
        else /* key == Key */
        {
            return false;
        }
    }

    public bool Exist(int key)
    {
        BinarySearchTreeNode? found = Find(key, out _);
        return found is not null;
    }

    public BinarySearchTreeNode? Find(int key, out BinarySearchTreeNode? parentOfFound)
    {
        return this.Find(key, parentOfSubtree: null, out parentOfFound);
    }

    public BinarySearchTreeNode? Delete(int key)
    {
        BinarySearchTreeNode? candidate = Find(key, out BinarySearchTreeNode? parentOfCandidate);
        return parentOfCandidate is null ? null : Delete(candidate!, parentOfCandidate);
    }

    private static BinarySearchTreeNode Delete(BinarySearchTreeNode node, BinarySearchTreeNode parentOfNode)
    {
        return parentOfNode.Left == node
            ? DeleteLeft(node, parentOfNode)
            : DeleteRight(node, parentOfNode);
    }

    private static BinarySearchTreeNode DeleteLeft(BinarySearchTreeNode node, BinarySearchTreeNode parentOfNode)
    {
        BinarySearchTreeNode deleted = new(node.Key);

        if (node.Left is null && node.Right is null)
        {
            parentOfNode.Left = null;
        }
        else if (node.Left is null && node.Right is not null)
        {
            parentOfNode.Left = node.Right;
        }
        else if (node.Left is not null && node.Right is null)
        {
            parentOfNode.Left = node.Left;
        }
        else if (node.Left is not null && node.Right is not null)
        {
            // find in order successor (the smallest value in the right subtree)
            BinarySearchTreeNode rightSubtree = node.Right;
            BinarySearchTreeNode parentOfRightSubtree = node;
            BinarySearchTreeNode min = rightSubtree.FindMin(parentOfRightSubtree, out BinarySearchTreeNode? parentOfMin);
            // TODO: 
        }

        return deleted;
    }

    private static BinarySearchTreeNode DeleteRight(BinarySearchTreeNode node, BinarySearchTreeNode parentOfNode)
    {
        BinarySearchTreeNode deleted = new(node.Key);

        if (node.Left is null && node.Right is null)
        {
            parentOfNode.Right = null;
        }
        else if (node.Left is null && node.Right is not null)
        {
            parentOfNode.Right = node.Right;
        }
        else if (node.Left is not null && node.Right is null)
        {
            parentOfNode.Right = node.Left;
        }
        else if (node.Left is not null && node.Right is not null)
        {
            // find in order successor (the smallest value in the right subtree)
            BinarySearchTreeNode rightSubtree = node.Right;
            BinarySearchTreeNode parentOfRightSubtree = node;
            BinarySearchTreeNode min = rightSubtree.FindMin(parentOfRightSubtree, out BinarySearchTreeNode? parentOfMin);
            // TODO:
        }

        return deleted;
    }

    public IEnumerator<int> GetEnumerator()
    {
        List<BinarySearchTreeNode> nodes = [];
        this.TraverseForward(nodes);

        foreach (BinarySearchTreeNode node in nodes)
            yield return node.Key;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

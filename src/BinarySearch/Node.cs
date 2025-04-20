using System.Collections;

namespace algos.BinarySearch;

internal class Node(int key) : IEnumerable<int>
{
    public int Key { get; } = key;
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public bool HasChildren => Left is not null && Right is not null;
    public bool HasChild => Left is not null || Right is not null;
    public Node Min => this.FindMin();
    public Node Max => this.FindMax();

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

            Left = new Node(key);
            return true;
        }
        else if (key > Key)
        {
            if (Right is not null)
            {
                return Right.Insert(key);
            }

            Right = new Node(key);
            return true;
        }
        else /* key == Key */
        {
            return false;
        }
    }

    public bool Exist(int key)
    {
        Node? found = Find(key, out _);
        return found is not null;
    }

    public Node? Find(int key, out Node? parentOfFound)
    {
        return this.Find(key, parentOfSubtree: null, out parentOfFound);
    }

    public Node? Delete(int key)
    {
        Node? candidate = Find(key, out Node? parentOfCandidate);
        return parentOfCandidate is null ? null : Delete(candidate!, parentOfCandidate);
    }

    private static Node Delete(Node node, Node parentOfNode)
    {
        return parentOfNode.Left == node
            ? DeleteLeft(node, parentOfNode)
            : DeleteRight(node, parentOfNode);
    }

    private static Node DeleteLeft(Node node, Node parentOfNode)
    {
        Node deleted = new(node.Key);

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
            Node rightSubtree = node.Right;
            Node parentOfRightSubtree = node;
            Node min = rightSubtree.FindMin(parentOfRightSubtree, out Node? parentOfMin);
            // TODO: 
        }

        return deleted;
    }

    private static Node DeleteRight(Node node, Node parentOfNode)
    {
        Node deleted = new(node.Key);

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
            Node rightSubtree = node.Right;
            Node parentOfRightSubtree = node;
            Node min = rightSubtree.FindMin(parentOfRightSubtree, out Node? parentOfMin);
            // TODO:
        }

        return deleted;
    }

    public IEnumerator<int> GetEnumerator()
    {
        List<Node> nodes = [];
        this.TraverseForward(nodes);

        foreach (Node node in nodes)
            yield return node.Key;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

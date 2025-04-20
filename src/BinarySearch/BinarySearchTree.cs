using System.Collections;

namespace algos.BinarySearch;

public class BinarySearchTree(int rootKey) : IEnumerable<int>
{
    private readonly Node root = new(rootKey);

    public bool Insert(int key) => root.Insert(key);

    public IEnumerator<int> GetEnumerator()
    {
        return root.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

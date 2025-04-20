using System.Collections;

namespace algos.BinarySearch;

public class BinarySearchTree(int rootKey) : IEnumerable<int>
{
    private readonly Node root = new(rootKey);

    public int Count => root.Count;

    public bool Insert(int key) => root.Insert(key);
    public bool Exist(int key) => root.Exist(key);
    public int? Delete(int key) => root.Delete(key)?.Key;

    public IEnumerator<int> GetEnumerator()
    {
        return root.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

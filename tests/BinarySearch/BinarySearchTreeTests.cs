namespace algos.tests.BinarySearch;

public class BinarySearchTreeTests
{
    [Fact]
    public void TestInsert()
    {
        BinarySearchTree tree = new(13);
        tree.Insert(5);
        tree.Insert(1);
        tree.Insert(7);
        tree.Insert(15);

        IEnumerable<int> expected = [1, 5, 7, 13, 15];
        IEnumerable<int> actual = tree;

        Assert.Equal(expected, actual);
    }
}
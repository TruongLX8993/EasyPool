namespace Easy.Pooling.Test;

[TestFixture]
public class PoolingTest
{
    private readonly IPool<PoolItem> _pool;
    public PoolingTest()
    {
        _pool = new Pool<PoolItem>(() => new PoolItem()
        {
            Id = Guid.NewGuid().ToString()
        });
    }
    [Test]
    public void AddItemShouldOk()
    {
        var poolItem = _pool.Get();
        Console.WriteLine(poolItem.Id);

        poolItem = _pool.Get();
        Console.WriteLine(poolItem.Id);

        _pool.Return(poolItem);

        poolItem = _pool.Get();
        Console.WriteLine(poolItem.Id);

    }
}
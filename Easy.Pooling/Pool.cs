using System.Collections.Concurrent;
using Easy.Pooling.Exceptions;
namespace Easy.Pooling;

public class Pool<T> : IPool<T> where T : IPoolItem
{

    private readonly IPoolItemFactory<T> _poolItemFactory;
    private readonly ConcurrentBag<T> _bag;
    private readonly PoolProperties _properties = PoolProperties.Default;

    public Pool(IPoolItemFactory<T> poolItemFactory)
    {
        _poolItemFactory = poolItemFactory;
        _bag = new ConcurrentBag<T>();
    }

    public Pool(Func<T> creator)
    {
        _poolItemFactory = new PoolFactory<T>(creator);
        _bag = new ConcurrentBag<T>();
    }

    public T Get()
    {
        return _bag.TryTake(out var item) ? item : CreateNewItem();
    }
    
    private T CreateNewItem()
    {

        if (_bag.Count >= _properties.PoolSize)
            throw new MaxPooItemException(_properties.PoolSize);
        return _poolItemFactory.Create();
    }
    
    public void Return(T t)
    {
        _bag.Add(t);
    }
}
namespace Easy.Pooling;

public class PoolFactory<T> : IPoolItemFactory<T> where T : IPoolItem
{

    private readonly Func<T> _creator;
    public PoolFactory(Func<T> creator)
    {
        _creator = creator;
    }
    public T Create()
    {
        return _creator.Invoke();
    }
}
namespace Easy.Pooling;

public interface IPool<T> where T : IPoolItem
{
    T Get();
    void Return(T t);
}
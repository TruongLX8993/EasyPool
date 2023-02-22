namespace Easy.Pooling;

public interface IPoolItemFactory<T> where T: IPoolItem
{
    T Create();
}
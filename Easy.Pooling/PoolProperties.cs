namespace Easy.Pooling;

public class PoolProperties
{
    public int PoolSize { get; }

    public PoolProperties(int poolSize)
    {
        PoolSize = poolSize;
    }

    public static PoolProperties Default
    {
        get => new PoolProperties(100);
    }
}
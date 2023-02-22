namespace Easy.Pooling.Exceptions;

public class MaxPooItemException : EasyPoolException
{
    public MaxPooItemException(int maxPoolSize) : base($"Pool count is max: {maxPoolSize}")
    {
    }
}
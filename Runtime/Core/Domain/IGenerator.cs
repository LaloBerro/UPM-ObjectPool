namespace ObjectPool.Runtime.Core.Domain
{
    public interface IGenerator<TGeneratedObject>
    {
        TGeneratedObject GetGeneratedObject();
    }
}
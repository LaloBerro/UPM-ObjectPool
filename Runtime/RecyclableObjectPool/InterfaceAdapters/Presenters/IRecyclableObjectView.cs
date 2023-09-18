namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters
{
    public interface IRecyclableObjectView
    {
        void Init();
        void Recycle();
    }
}
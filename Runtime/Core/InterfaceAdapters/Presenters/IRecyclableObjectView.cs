namespace ObjectPool.Runtime.Core.InterfaceAdapters.Presenters
{
    public interface IRecyclableObjectView
    {
        void Init();
        void Recycle();
    }
}
namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers
{
    public interface ICustomObjectToRealtimeObjectObserver<TCustomObject>
    {
        void MapCustomObjectAndNotify(TCustomObject customObject);
    }
}
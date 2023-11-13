namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories
{
    public interface IRealtimeObjectRepository<TCustomObject, TRealtimeObject>
    {
        void AddRealtimeObjectFromCustomObject(TCustomObject customObject, TRealtimeObject realtimeObject);
        TRealtimeObject GetRealtimeObjectByCustomObject(TCustomObject customObject);
    }
}
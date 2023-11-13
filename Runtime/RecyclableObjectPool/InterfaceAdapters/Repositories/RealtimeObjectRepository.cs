using System.Collections.Generic;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories
{
    public class RealtimeObjectRepository<TCustomObject, TRealtimeObject> : IRealtimeObjectRepository<TCustomObject, TRealtimeObject>
    {
        private readonly Dictionary<TCustomObject, TRealtimeObject> _realtimeObjects = new Dictionary<TCustomObject, TRealtimeObject>();
        
        public void AddRealtimeObjectFromCustomObject(TCustomObject customObject, TRealtimeObject realtimeObject)
        {
            _realtimeObjects.Add(customObject, realtimeObject);
        }

        public TRealtimeObject GetRealtimeObjectByCustomObject(TCustomObject customObject)
        {
            return _realtimeObjects[customObject];
        }
    }
}
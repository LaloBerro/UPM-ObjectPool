using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using UnityEngine;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine
{
    public class RecyclableObjectViewToGameObjectObserver : ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView>
    {
        private readonly IRealtimeObjectRepository<IRecyclableObjectView, GameObject> _realtimeObjectRepository;

        private readonly IObjectObserver<GameObject> _objectObserver;

        public RecyclableObjectViewToGameObjectObserver(IRealtimeObjectRepository<IRecyclableObjectView, GameObject> realtimeObjectRepository, IObjectObserver<GameObject> objectObserver)
        {
            _realtimeObjectRepository = realtimeObjectRepository;
            _objectObserver = objectObserver;
        }

        public void MapCustomObjectAndNotify(IRecyclableObjectView recyclableObjectView)
        {
            GameObject gameObject = _realtimeObjectRepository.GetRealtimeObjectByCustomObject(recyclableObjectView);

            _objectObserver.Notify(gameObject);
        }
    }
}
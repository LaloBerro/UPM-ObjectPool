using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using UnityEngine;
using Zenject;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class RecyclableObjectViewToGameObjectObserverZinstaller : CustomObjectToRealtimeObjectObserverZinstaller<IRecyclableObjectView>
    {
        [Inject]
        private IRealtimeObjectRepository<IRecyclableObjectView, GameObject> _realtimeObjectRepository;

        [Inject]
        private IObjectObserver<GameObject> _objectObserver;
        
        protected override ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView> GetInitializedClass()
        {
            return new RecyclableObjectViewToGameObjectObserver(_realtimeObjectRepository, _objectObserver);
        }
    }
}
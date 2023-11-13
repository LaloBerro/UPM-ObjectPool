using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using UnityEngine;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class InitializedRecyclableObjectPositionerZinstaller : ObjectOnPoolChangeSubscriberZinstaller<GameObject>
    {
        [Header("References")] 
        [SerializeField] private Transform _positionTransform;
        
        protected override ObjectOnPoolChangeSubscriber<GameObject> GetObjectOnPoolChangeSubscriber(IObjectObserver<GameObject> objectObserver)
        {
            return new InitializedRecyclableObjectPositioner(objectObserver, _positionTransform);
        }
    }
}
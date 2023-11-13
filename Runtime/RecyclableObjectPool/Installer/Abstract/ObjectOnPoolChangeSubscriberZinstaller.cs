using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public abstract class ObjectOnPoolChangeSubscriberZinstaller<TRealtimeObject> : InstanceZinstaller<ObjectOnPoolChangeSubscriber<TRealtimeObject>>
    {
        [Inject]
        private  IObjectObserver<TRealtimeObject> _objectObserver;
        
        protected override ObjectOnPoolChangeSubscriber<TRealtimeObject> GetInitializedClass()
        {
            return GetObjectOnPoolChangeSubscriber(_objectObserver);
        }

        protected abstract ObjectOnPoolChangeSubscriber<TRealtimeObject> GetObjectOnPoolChangeSubscriber(IObjectObserver<TRealtimeObject> objectObserver);
    }
}
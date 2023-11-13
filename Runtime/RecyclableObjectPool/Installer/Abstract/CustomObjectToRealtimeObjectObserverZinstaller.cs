using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public abstract class CustomObjectToRealtimeObjectObserverZinstaller<TCustomObject> : InstanceZinstaller<ICustomObjectToRealtimeObjectObserver<TCustomObject>>
    {
        
    }
}
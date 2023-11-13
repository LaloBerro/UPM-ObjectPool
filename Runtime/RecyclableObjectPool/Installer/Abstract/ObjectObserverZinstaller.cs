using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public abstract class ObjectObserverZinstaller<TObject> : InstanceZinstaller<IObjectObserver<TObject>>
    {
        protected override IObjectObserver<TObject> GetInitializedClass()
        {
            return new ObjectObserver<TObject>();
        }
    }
}
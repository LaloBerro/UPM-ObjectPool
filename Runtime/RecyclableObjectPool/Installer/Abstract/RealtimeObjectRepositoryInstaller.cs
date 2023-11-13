using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using UnityEngine;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public abstract class RealtimeObjectRepositoryInstaller<TCustomObject, TRealtimeObject> : InstanceZinstaller<IRealtimeObjectRepository<TCustomObject, TRealtimeObject>>
    {
        protected override IRealtimeObjectRepository<TCustomObject, TRealtimeObject> GetInitializedClass()
        {
            return new RealtimeObjectRepository<TCustomObject, TRealtimeObject>();
        }
    }
}
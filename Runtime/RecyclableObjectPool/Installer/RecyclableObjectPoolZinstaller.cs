using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using UnityEngine;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class RecyclableObjectPoolZinstaller : CachedInstanceZinstaller<IObjectPool<IRecyclableObjectView>>
    {
        [Header("Config")]
        [SerializeField] private int _maxInstancedObjects;
        
        [Inject]
        private IGenerator<IRecyclableObjectView> _recyclableObjectGenerator;
        
        [Inject]
        private ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView> _customObjectToRealtimeObjectObserver;
        
        protected override IObjectPool<IRecyclableObjectView> GetInitializedClass()
        {
            return new RecyclableObjectPool(_recyclableObjectGenerator, _maxInstancedObjects, _customObjectToRealtimeObjectObserver);
        }
    }
}
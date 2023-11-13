using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using UnityEngine;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class RecyclableObjectGeneratorZinstaller : CachedInstanceZinstaller<IGenerator<IRecyclableObjectView>>
    {
        [Header("References")] 
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private GameObject _prefabToGenerate;
        
        [Inject]
        private readonly IRealtimeObjectRepository<IRecyclableObjectView, GameObject> _realtimeObjectRepository;
        
        protected override IGenerator<IRecyclableObjectView> GetInitializedClass()
        {
            return new RecyclableObjectGenerator(_parentTransform, _prefabToGenerate, _realtimeObjectRepository);
        }
    }
}
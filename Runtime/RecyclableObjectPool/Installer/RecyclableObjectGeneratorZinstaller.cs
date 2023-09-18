using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using UnityEngine;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class RecyclableObjectGeneratorZinstaller : InstanceZinstaller<IGenerator<IRecyclableObjectView>>
    {
        [Header("References")] 
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private GameObject _prefabToGenerate;
        
        protected override IGenerator<IRecyclableObjectView> GetInitializedClass()
        {
            return new RecyclableObjectGenerator(_parentTransform, _prefabToGenerate);
        }
    }
}
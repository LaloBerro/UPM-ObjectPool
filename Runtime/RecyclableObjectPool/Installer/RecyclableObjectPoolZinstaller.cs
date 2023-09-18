
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using UnityEngine;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class RecyclableObjectPoolZinstaller : InstanceZinstaller<IObjectPool<IRecyclableObjectView>>
    {
        [Header("Config")]
        private int _maxInstancedObjects;
        
        [Inject]
        private IGenerator<IRecyclableObjectView> _recyclableObjectGenerator;
        
        protected override IObjectPool<IRecyclableObjectView> GetInitializedClass()
        {
            return new RecyclableObjectPool(_recyclableObjectGenerator, _maxInstancedObjects);
        }
    }
}


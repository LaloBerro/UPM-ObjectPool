using System;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine
{
    public class RecyclableObjectGenerator : IGenerator<IRecyclableObjectView>
    {
        private readonly Transform _parentTransform;
        private readonly GameObject _prefabToGenerate;

        private readonly IRealtimeObjectRepository<IRecyclableObjectView, GameObject> _realtimeObjectRepository;

        public RecyclableObjectGenerator(Transform parentTransform, GameObject prefabToGenerate, IRealtimeObjectRepository<IRecyclableObjectView, GameObject> realtimeObjectRepository)
        {
            _parentTransform = parentTransform;
            _prefabToGenerate = prefabToGenerate;
            _realtimeObjectRepository = realtimeObjectRepository;
        }

        public IRecyclableObjectView GetGeneratedObject()
        {
            GameObject instancedGameObject = Object.Instantiate(_prefabToGenerate, _parentTransform);

            IRecyclableObjectView recyclableObjectView = instancedGameObject.GetComponent<IRecyclableObjectView>();
            
            _realtimeObjectRepository.AddRealtimeObjectFromCustomObject(recyclableObjectView, instancedGameObject);

            if (ReferenceEquals(recyclableObjectView, null))
                throw new Exception("[RecyclableObjectGenerator] Instanced GameObject doesn't contains a component with IRecyclableObjectView");

            return recyclableObjectView;
        }
    }
}
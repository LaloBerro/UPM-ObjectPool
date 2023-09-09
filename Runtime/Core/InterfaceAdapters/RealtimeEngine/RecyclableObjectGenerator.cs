using System;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.Core.InterfaceAdapters.Presenters;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ObjectPool.Runtime.Core.InterfaceAdapters.RealtimeEngine
{
    public class RecyclableObjectGenerator : IGenerator<IRecyclableObjectView>
    {
        private readonly Transform _parentTransform;
        private readonly GameObject _prefabToGenerate;

        public RecyclableObjectGenerator(Transform parentTransform, GameObject prefabToGenerate)
        {
            _parentTransform = parentTransform;
            _prefabToGenerate = prefabToGenerate;
        }

        public IRecyclableObjectView GetGeneratedObject()
        {
            GameObject instancedGameObject = Object.Instantiate(_prefabToGenerate, _parentTransform);

            IRecyclableObjectView recyclableObjectView = instancedGameObject.GetComponent<IRecyclableObjectView>();

            if (ReferenceEquals(recyclableObjectView, null))
                throw new Exception("[RecyclableObjectGenerator] Instanced GameObject doesn't contains a component with IRecyclableObjectView");

            return recyclableObjectView;
        }
    }
}
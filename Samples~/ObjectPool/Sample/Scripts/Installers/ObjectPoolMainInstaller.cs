using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Repositories;
using ObjectPool.Runtime.RecyclableObjectPools.View;
using UnityEngine;

namespace ObjectPool.Runtime.RecyclableObjectPools.Installers
{
    public class ObjectPoolMainInstaller : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameObject _recyclableObjectViewPrefab;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private Transform _positionTransform;

        [SerializeField] private int _maxPoolSize = 100;
        
        private IObjectPool<IRecyclableObjectView> _objectObjectPool;

        public IObjectPool<IRecyclableObjectView> ObjectPool => _objectObjectPool;

        private void Awake()
        {
            Install();
        }

        private void Install()
        {
            _recyclableObjectViewPrefab.AddComponent<SetActiveRecyclableObject>();

            IObjectObserver<GameObject> objectObserver = new ObjectObserver<GameObject>();
            IRealtimeObjectRepository<IRecyclableObjectView, GameObject> realtimeObjectRepository = new RealtimeObjectRepository<IRecyclableObjectView, GameObject>();
            ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView> customObjectToRealtimeObjectObserver = new RecyclableObjectViewToGameObjectObserver(realtimeObjectRepository, objectObserver);
            
            IGenerator<IRecyclableObjectView> generator = new RecyclableObjectGenerator(_parentTransform, _recyclableObjectViewPrefab, realtimeObjectRepository);
            _objectObjectPool = new RecyclableObjectPool(generator, _maxPoolSize, customObjectToRealtimeObjectObserver);

            ObjectOnPoolChangeSubscriber<GameObject> objectOnPoolChangeSubscriber = new InitializedRecyclableObjectPositioner(objectObserver, _positionTransform);
        }
    }
}
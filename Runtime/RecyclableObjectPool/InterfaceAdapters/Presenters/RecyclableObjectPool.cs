using System;
using System.Collections.Generic;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters
{
    public class RecyclableObjectPool : IObjectPool<IRecyclableObjectView>, IDisposable
    {
        private readonly IGenerator<IRecyclableObjectView> _recyclableObjectGenerator;
        private readonly int _maxInstancedObjects;
        
        private readonly Queue<IRecyclableObjectView> _objectsPool;
        private readonly List<IRecyclableObjectView> _objectsInUse;

        private readonly ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView> _customObjectToRealtimeObjectObserver;
        
        public RecyclableObjectPool(IGenerator<IRecyclableObjectView> recyclableObjectGenerator, int maxInstancedObjects, ICustomObjectToRealtimeObjectObserver<IRecyclableObjectView> customObjectToRealtimeObjectObserver)
        {
            _recyclableObjectGenerator = recyclableObjectGenerator;
            _maxInstancedObjects = maxInstancedObjects;
            _customObjectToRealtimeObjectObserver = customObjectToRealtimeObjectObserver;

            _objectsPool = new Queue<IRecyclableObjectView>();
            _objectsInUse = new List<IRecyclableObjectView>();
        }

        public IRecyclableObjectView GetObject()
        {
            IRecyclableObjectView recyclableObjectView = GetRecycleObject();

            _objectsInUse.Add(recyclableObjectView);

            recyclableObjectView.Init();
            
            _customObjectToRealtimeObjectObserver.MapCustomObjectAndNotify(recyclableObjectView);

            return recyclableObjectView;
        }
        
        private IRecyclableObjectView GetRecycleObject()
        {
            IRecyclableObjectView recyclableObjectView;

            bool thereAreObjectInThePool = _objectsPool.Count > 0;
            if (thereAreObjectInThePool)
            {
                recyclableObjectView = _objectsPool.Dequeue();
                return recyclableObjectView;
            }
            
            bool isThePoolFull = _objectsInUse.Count >= _maxInstancedObjects;
            if (isThePoolFull)
            {
                recyclableObjectView = GetObjectInUse();
                return recyclableObjectView;
            }

            recyclableObjectView = _recyclableObjectGenerator.GetGeneratedObject();
            return recyclableObjectView;
        }
        
        private IRecyclableObjectView GetObjectInUse()
        {
            IRecyclableObjectView recyclableObjectView = _objectsInUse[0];
            
            recyclableObjectView.Recycle();

            _objectsInUse.Remove(recyclableObjectView);

            return recyclableObjectView;
        }

        public void RecycleObject(IRecyclableObjectView objectViewToRecycle)
        {
            objectViewToRecycle.Recycle();

            _objectsInUse.Remove(objectViewToRecycle);

            _objectsPool.Enqueue(objectViewToRecycle);
        }

        public void RecycleAll()
        {
            for (var i = _objectsInUse.Count - 1; i >= 0; i--)
            {
                RecycleObject(_objectsInUse[i]);
            }
        }

        public int GetPoolSize()
        {
            return _objectsInUse.Count;
        }

        public void Dispose()
        {
            
        }
    }
}
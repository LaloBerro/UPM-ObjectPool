using System.Collections.Generic;
using ObjectPool.Runtime.Core.Domain;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters
{
    public class RecyclableObjectPool : IObjectPool<IRecyclableObjectView>
    {
        private readonly IGenerator<IRecyclableObjectView> _recyclableObjectGenerator;
        private readonly int _maxInstancedObjects;
        
        private readonly Queue<IRecyclableObjectView> _objectsPool;
        private readonly List<IRecyclableObjectView> _objectsInUse;
        
        public RecyclableObjectPool(IGenerator<IRecyclableObjectView> recyclableObjectGenerator, int maxInstancedObjects)
        {
            _recyclableObjectGenerator = recyclableObjectGenerator;
            _maxInstancedObjects = maxInstancedObjects;

            _objectsPool = new Queue<IRecyclableObjectView>();
            _objectsInUse = new List<IRecyclableObjectView>();
        }

        public IRecyclableObjectView GetObject()
        {
            IRecyclableObjectView recyclableObjectView = GetRecycleObject();

            _objectsInUse.Add(recyclableObjectView);

            recyclableObjectView.Init();

            return recyclableObjectView;
        }
        
        private IRecyclableObjectView GetRecycleObject()
        {
            IRecyclableObjectView recyclableObjectView;

            bool thereAreObjectInThePool = ThereAreObjectInThePool();
            if (thereAreObjectInThePool)
            {
                recyclableObjectView = _objectsPool.Dequeue();
                return recyclableObjectView;
            }

            bool isThePoolFull = IsThePoolFull();
            if (isThePoolFull)
            {
                recyclableObjectView = GetObjectInUse();
                return recyclableObjectView;
            }

            recyclableObjectView = _recyclableObjectGenerator.GetGeneratedObject();
            return recyclableObjectView;
        }
        
        private bool ThereAreObjectInThePool()
        {
            return _objectsPool.Count > 0;
        }

        private bool IsThePoolFull()
        {
            return _objectsPool.Count >= _maxInstancedObjects;
        }
        
        private IRecyclableObjectView GetObjectInUse()
        {
            IRecyclableObjectView recyclableObjectView = _objectsInUse[0];

            RecycleObject(recyclableObjectView);

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
    }
}
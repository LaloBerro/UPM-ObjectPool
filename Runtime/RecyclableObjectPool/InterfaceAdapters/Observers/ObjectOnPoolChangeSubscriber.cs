using System;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers
{
    public abstract  class ObjectOnPoolChangeSubscriber<TRealtimeObject> : IDisposable
    {
        private readonly IObjectObserver<TRealtimeObject> _objectObserver;

        public ObjectOnPoolChangeSubscriber(IObjectObserver<TRealtimeObject> objectObserver)
        {
            _objectObserver = objectObserver;

            _objectObserver.OnObjectChanged += ChangeObject;
        }

        protected abstract void ChangeObject(TRealtimeObject realtimeObject);
        
        public void Dispose()
        {
            _objectObserver.OnObjectChanged -= ChangeObject;
        }
    }
}
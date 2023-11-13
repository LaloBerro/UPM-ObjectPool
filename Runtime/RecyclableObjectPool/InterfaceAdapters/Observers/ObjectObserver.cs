using System;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers
{
    public class ObjectObserver<TObject> : IObjectObserver<TObject>
    {
        public Action<TObject> OnObjectChanged { get; set; }
        
        public void Notify(TObject gameObject)
        {
            OnObjectChanged?.Invoke(gameObject);
        }
    }
}
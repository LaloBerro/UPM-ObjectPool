using System;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers
{
    public interface IObjectObserver<TObject>
    {
        Action<TObject> OnObjectChanged { get; set;}
        void Notify(TObject gameObject);
    }
}
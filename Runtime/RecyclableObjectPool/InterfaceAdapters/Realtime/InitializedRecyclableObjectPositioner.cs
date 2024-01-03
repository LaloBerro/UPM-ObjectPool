using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Observers;
using UnityEngine;

namespace ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.RealtimeEngine
{
    public class InitializedRecyclableObjectPositioner : ObjectOnPoolChangeSubscriber<GameObject>
    {
        private readonly Transform _positionTransform;

        public InitializedRecyclableObjectPositioner(IObjectObserver<GameObject> objectObserver, Transform positionTransform) : base(objectObserver)
        {
            _positionTransform = positionTransform;
        }

        protected override void ChangeObject(GameObject gameObject)
        {
            gameObject.transform.position = _positionTransform.position;
        }
    }
}
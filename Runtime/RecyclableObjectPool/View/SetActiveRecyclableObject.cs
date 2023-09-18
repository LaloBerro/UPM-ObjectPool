using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using UnityEngine;

namespace ObjectPool.Runtime.RecyclableObjectPools.View
{
    public class SetActiveRecyclableObject : MonoBehaviour, IRecyclableObjectView
    {
        public void Init()
        {
            gameObject.SetActive(true);
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
        }
    }
}
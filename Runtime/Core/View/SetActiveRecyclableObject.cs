using ObjectPool.Runtime.Core.InterfaceAdapters.Presenters;
using UnityEngine;

namespace ObjectPool.Runtime.Core.View
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
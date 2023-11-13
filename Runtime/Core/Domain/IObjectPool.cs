using System;

namespace ObjectPool.Runtime.Core.Domain
{
    public interface IObjectPool<TObject>
    {
        TObject GetObject();
        void RecycleObject(TObject objectToRecycle);
        void RecycleAll();
        int GetPoolSize();
    }
}
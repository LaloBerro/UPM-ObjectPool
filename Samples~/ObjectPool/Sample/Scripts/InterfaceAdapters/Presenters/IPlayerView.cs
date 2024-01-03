using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;

public interface IPlayerView : IRecyclableObjectView
{
    void SetName(string playerName);
}
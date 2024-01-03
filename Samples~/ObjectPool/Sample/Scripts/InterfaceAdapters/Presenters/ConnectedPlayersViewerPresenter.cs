using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;

public class ConnectedPlayersViewerPresenter : IConnectedPlayersViewerPresenter
{
    private readonly IObjectPool<IRecyclableObjectView> _objectPool;

    public ConnectedPlayersViewerPresenter(IObjectPool<IRecyclableObjectView> objectPool)
    {
        _objectPool = objectPool;
    }

    public void ShowPlayer(string playerName)
    {
        IPlayerView playerView = (IPlayerView)_objectPool.GetObject();

        playerView.SetName(playerName);
    }
}
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.RecyclableObjectPools.Installers;
using ObjectPool.Runtime.RecyclableObjectPools.InterfaceAdapters.Presenters;
using UnityEngine;

public class ConnectedPlayersViewerInstaller : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private ObjectPoolMainInstaller _objectPoolMainInstaller;
    
    private void Start()
    {
        Install();
    }

    private void Install()
    {
        IObjectPool<IRecyclableObjectView> objectPool = _objectPoolMainInstaller.ObjectPool;
        IConnectedPlayersViewerPresenter connectedPlayersViewerPresenter = new ConnectedPlayersViewerPresenter(objectPool);

        ConnectedPlayersViewer connectedPlayersViewer = new ConnectedPlayersViewer(connectedPlayersViewerPresenter);
    }
}
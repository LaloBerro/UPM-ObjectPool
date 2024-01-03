using System;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

public class ConnectedPlayersViewer
{
    private readonly IConnectedPlayersViewerPresenter _connectedPlayersViewerPresenter;

    public ConnectedPlayersViewer(IConnectedPlayersViewerPresenter connectedPlayersViewerPresenter)
    {
        _connectedPlayersViewerPresenter = connectedPlayersViewerPresenter;

        ViewPlayers();
    }

    private async void ViewPlayers()
    {
        int randomPlayerNumber = Random.Range(100, 10000);
        string playerName = string.Concat("Player", randomPlayerNumber);
        _connectedPlayersViewerPresenter.ShowPlayer(playerName);

        await Task.Delay(TimeSpan.FromSeconds(1));
        
        ViewPlayers();
    }
}
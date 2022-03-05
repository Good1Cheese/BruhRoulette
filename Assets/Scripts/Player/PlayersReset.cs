using UnityEngine;
using Zenject;

public class PlayersReset : MonoBehaviour
{
    private GameRestart _gameRestart;
    private PlayersList _playersList;

    [Inject]
    public void Construct(GameRestart gameRestart, PlayersList playersList)
    {
        _gameRestart = gameRestart;
        _playersList = playersList;
    }

    private void Awake()
    {
        _gameRestart.Restarted += Refresh;
    }

    private void Refresh()
    {
        for (int i = 0; i < _playersList.List.Count; i++)
        {
            _playersList[i].TogglersToggle.RpcToggleWithoutDelay(true);
        }
    }

    private void OnDestroy()
    {
        _gameRestart.Restarted -= Refresh;
    }
}
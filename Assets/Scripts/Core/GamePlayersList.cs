using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlayersList : MonoBehaviour
{
    private GameStart _gameStart;
    private PlayersList _playersList;
    private RevolverShot _revolverShot;
    private GameProgress _gameProgress;

    public List<GamePlayer> List { get; set; }

    [Inject]
    public void Construct(GameStart gameStart, PlayersList playersList, RevolverShot revolverShot, GameProgress gameProgress)
    {
        _gameStart = gameStart;
        _playersList = playersList;
        _revolverShot = revolverShot;
        _gameProgress = gameProgress;
    }

    private void Start()
    {
        _gameStart.Started += UpdatePlayers;
        _revolverShot.Done += RemoveCurrent;
    }

    private void UpdatePlayers()
    {
        List = new List<GamePlayer>(_playersList.List);
    }

    private void RemoveCurrent()
    {
        List.Remove(_gameProgress.CurrentPlayer);
    }

    public GamePlayer GetRandom()
    {
        int randomIndex = Random.Range(0, List.Count);
        GamePlayer result = List[randomIndex];

        return result;
    }

    private void OnDestroy()
    {
        _gameStart.Started -= UpdatePlayers;
        _revolverShot.Done -= RemoveCurrent;
    }
}
using UnityEngine;
using Zenject;

public class GameStarter : MonoBehaviour
{
    private RouletteGame _rouletteGame;
    private GameStartUIToggler _gameStartUIToggler;

    [Inject]
    public void Construct(RouletteGame rouletteGame)
    {
        _rouletteGame = rouletteGame;
    }

    private void Awake()
    {
        _gameStartUIToggler = GetComponent<GameStartUIToggler>();
    }

    public void StartGame()
    {
        _gameStartUIToggler.Toggle(false);
        _rouletteGame.StartGame();
    }
}
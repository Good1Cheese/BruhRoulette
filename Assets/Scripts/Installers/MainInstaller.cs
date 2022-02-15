using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private GameObject _clientPlayer;
    [SerializeField] private GameObject _hostPlayer;

    public override void InstallBindings()
    {
        BindPlayer();
        BindInputHandlers();

        Container.BindInstance(GetComponent<GameStart>())
            .AsSingle();

        Container.BindInstance(GetComponent<GameProgress>())
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container.BindInstance(GetComponent<PlayerSpawnPositionSetter>())
            .AsSingle();

        Container.BindInstance(GetComponent<PlayersList>())
            .AsSingle();

        Container.BindInstance(_clientPlayer)
            .WithId("Client")
            .AsCached();

        Container.BindInstance(_hostPlayer)
            .WithId("Host")
            .AsCached();

        Container.BindFactory<Transform, PlayerFactory>().FromComponentInNewPrefab(_clientPlayer);
    }

    private void BindInputHandlers()
    {
        Container.BindInstance(GetComponent<FireButtonInputHandler>())
            .AsSingle();

        Container.BindInstance(GetComponent<ScrollButtonInputHandler>())
            .AsSingle();

        Container.BindInstance(GetComponent<StartButtonPressHandler>())
            .AsSingle();
    }
}
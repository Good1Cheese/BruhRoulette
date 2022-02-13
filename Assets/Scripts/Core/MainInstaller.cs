using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private GameObject _clientPlayer;
    [SerializeField] private GameObject _hostPlayer;

    public override void InstallBindings()
    {
        BindPlayer();

        Container.BindInstance(GetComponent<RouletteGame>())
            .AsSingle();

        Container.BindInstance(GetComponent<GameSteps>())
            .AsSingle();

        Container.BindInstance(GetComponent<FireInputHandler>())
            .AsSingle();

        Container.BindInstance(GetComponent<PlayersList>())
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container.BindInstance(GetComponent<PlayerPositionSetter>())
            .AsSingle();

        Container.BindInstance(_clientPlayer)
            .WithId("Client")
            .AsCached();

        Container.BindInstance(_hostPlayer)
            .WithId("Host")
            .AsCached();


        Container.BindFactory<Transform, PlayerFactory>().FromComponentInNewPrefab(_clientPlayer);
    }
}
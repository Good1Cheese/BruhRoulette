using System;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private GameObject _hostPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.BindInstance(_clientPrefab)
            .WithId("Client")
            .AsCached();

        Container.BindInstance(_hostPrefab)
            .WithId("Host")
            .AsCached();

        Container.Bind<PlayerFactory>().AsSingle();
        Container.BindIFactory<Transform, PlayerFactory>().AsSingle();
    }
}
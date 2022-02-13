using System;
using UnityEngine;
using Zenject;

public class FireInputHandler : MonoBehaviour
{
    private RouletteGame _rouletteGame;

    public uint ExpectedNetId { get; set; }
    public Action Fired { get; set; }

    [Inject]
    public void Construct(RouletteGame rouletteGame)
    {
        _rouletteGame = rouletteGame;
    }

    public void Handle(uint netId)
    {
        if (!_rouletteGame.GameStarted || netId != ExpectedNetId) { return; }

        Fired?.Invoke();
    }
}
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<GameStep>())
            .AsSingle();
    }
}
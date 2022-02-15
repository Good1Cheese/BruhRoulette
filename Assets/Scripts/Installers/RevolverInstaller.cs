using Zenject;

public class RevolverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(GetComponent<RevolverLoad>())
            .AsSingle();
    }
}
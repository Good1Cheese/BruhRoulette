using Zenject;

public class RevolverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RevolverShot>()
                 .FromNew()
                 .AsSingle();

        Container.Bind<RevolverClick>()
                 .FromNew()
                 .AsSingle();
    }
}
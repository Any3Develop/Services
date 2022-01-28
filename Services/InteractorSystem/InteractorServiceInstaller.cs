using Zenject;

namespace Services.InteractorSystem
{
    public class InteractorServiceInstaller : Installer<InteractorServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<InteractorStorage>()
                .AsSingle();
        }
    }
}
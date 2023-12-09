using Scripts.Infrastructure.StateMachine;
using Scripts.Tools;
using Zenject;

namespace Scripts.Infrastructure.Installers
{
    public class StatesInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle();

            Initialize();
        }

        public void Initialize()
        {
            Container.Resolve<GameStateMachine>()
                .With(gameStateMachine => gameStateMachine.CreateStates())
                .Enter<BootstrapState>();
        }
    }
}
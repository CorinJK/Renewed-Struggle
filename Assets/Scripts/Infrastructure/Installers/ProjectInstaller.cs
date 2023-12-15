using Scripts.Infrastructure.StateMachine;
using Scripts.Services.Factory;
using Scripts.Services.SceneLoader;
using Scripts.Tools;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        [Header("References")]
        [SerializeField] private GameObject _coroutineRunnerPrefab;

        public override void InstallBindings()
        {
            BindMonoServices();
            BindSceneLoader();
            BindGameStateMachine();
            MakeInitializable();
        }

        public void Initialize()
        {
            Container.Resolve<GameStateMachine>()
                .With(gameStateMachine => gameStateMachine.CreateStates())
                .Enter<BootstrapState>();
        }

        private void BindMonoServices()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefab(_coroutineRunnerPrefab).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
        }

        private void MakeInitializable()
        {
            Container.Bind<IInitializable>().FromInstance(this).AsSingle();
        }
    }
}
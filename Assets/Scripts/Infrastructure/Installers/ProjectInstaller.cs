using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AssetManagement;
using Scripts.Services.Factory;
using Scripts.Services.Input;
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
        [SerializeField] private GameObject _loadingScreenPrebab;

        public override void InstallBindings()
        {
            BindInputService();
            BindSceneLoader();
            BindServices();
            BindGameStateMachine();
            MakeInitializable();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.BindInterfacesTo<KeyboardInputService>().AsSingle().NonLazy();
            else
                Container.BindInterfacesTo<MobileInputService>().AsSingle().NonLazy();
        }

        public void Initialize()
        {
            Container.Resolve<GameStateMachine>()
                .With(gameStateMachine => gameStateMachine.CreateStates())
                .Enter<BootstrapState>();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefab(_coroutineRunnerPrefab).AsSingle();
            Container.Bind<ILoadingScreen>().To<LoadingScreen>().FromComponentInNewPrefab(_loadingScreenPrebab).AsSingle();
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IPrefabFactory>().To<PrefabFactory>().AsSingle();
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
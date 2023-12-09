using Scripts.Player;
using Scripts.Services.Factory;
using Scripts.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installers
{
    public class ServicesInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private PlayerMovement _playerMovement;
        
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
            Container.Bind<IStatesFactory>().To<StateFactory>().AsSingle();

            if (_playerMovement != null)
            {
                Container.BindInterfacesTo<PlayerMovement>().FromInstance(_playerMovement).AsSingle().NonLazy();
            }
        }
    }
}
using Scripts.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class BootstrapState : IState
    {
        private const string BootstrapScene = "Bootstrap";
        
        private GameStateMachine _gameStateMachine;
        private ISceneLoaderService _sceneLoaderService;

        [Inject]
        public void Consruct(GameStateMachine gameStateMachine, ISceneLoaderService sceneLoaderService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoaderService = sceneLoaderService;
        }

        public void Enter()
        {
            Debug.Log("Enter BootstrapState");
            _sceneLoaderService.Load(BootstrapScene, OnLoaded);
        }

        private void OnLoaded() => 
            _gameStateMachine.Enter<LoadLevelState>();

        public void Exit()
        {
        }
    }
}
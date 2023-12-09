using Scripts.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class LoadLevelState : IState
    {
        private const string BattlefieldScene = "Battlefield";
        
        private GameStateMachine _gameStateMachine;
        private ISceneLoaderService _sceneLoaderService;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, ISceneLoaderService sceneLoaderService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoaderService = sceneLoaderService;
        }

        public void Enter()
        {
            Debug.Log("Enter LoadLevelState");
            _sceneLoaderService.Load(BattlefieldScene, OnLoaded);
        }

        private void OnLoaded()
        {
        }

        public void Exit()
        {
        }
    }
}
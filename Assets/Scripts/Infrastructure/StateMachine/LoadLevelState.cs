using Scripts.Player;
using Scripts.Services.Camera;
using Scripts.Services.Factory;
using Scripts.Services.Input;
using Scripts.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class LoadLevelState : IState
    {
        private const string BattlefieldScene = "Battle";
        private const string InitialPointTag = "InitialPoint";
        
        private GameStateMachine _gameStateMachine;
        private ISceneLoaderService _sceneLoaderService;
        private IPrefabFactory _prefabFactory;
        private IInputService _inputService;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, ISceneLoaderService sceneLoaderService, IPrefabFactory prefabFactory, IInputService inputService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoaderService = sceneLoaderService;
            _prefabFactory = prefabFactory;
            _inputService = inputService;
        }

        public void Enter()
        {
            Debug.Log("Enter LoadLevelState");
            _sceneLoaderService.Load(BattlefieldScene, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            Debug.Log("OnLoaded");
            PlayerMovement player = InitPlayer();
            player.Init(_inputService);
            
            
            InitHud();
            InitCamera(player);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private PlayerMovement InitPlayer()
        {
            return _prefabFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));
        }

        private void InitHud()
        {
            _prefabFactory.CreateHud();
        }

        private static void InitCamera(PlayerMovement player)
        {
            if (Camera.main.TryGetComponent(out CameraFollow cameraFollow))
            {
                cameraFollow.Follow(player.transform);
            }
        }
    }
}
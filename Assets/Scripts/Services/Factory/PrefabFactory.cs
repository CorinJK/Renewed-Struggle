using System.Collections.Generic;
using Scripts.Player;
using Scripts.Services.AssetManagement;
using UnityEngine;
using Zenject;

namespace Scripts.Services.Factory
{
    public class PrefabFactory : IPrefabFactory
    { 
        private const string PlayerPath = "Player/Player";
        private const string HudPath = "UI/HUD";

        private readonly IAssetProvider _assetProvider;

        [Inject]
        private PrefabFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public PlayerMovement CreatePlayer(GameObject at)
        {
            return _assetProvider.Instantiate<PlayerMovement>(PlayerPath, at: at.transform.position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(HudPath);
        }
    }
}
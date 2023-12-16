using Scripts.Player;
using UnityEngine;

namespace Scripts.Services.Factory
{
    public interface IPrefabFactory : IService
    {
        PlayerMovement CreatePlayer(GameObject at);
        void CreateHud();
    }
}
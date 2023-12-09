using Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }
        
        private void BindInputService()
        {
            if (Application.isEditor)
                Container.BindInterfacesTo<KeyboardInputService>().AsSingle().NonLazy();
            else
                Container.BindInterfacesTo<MobileInputService>().AsSingle().NonLazy();
        }
    }
}
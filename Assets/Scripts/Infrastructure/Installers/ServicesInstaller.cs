using Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.Bind<InputService>().To<KeyboardInputService>().AsSingle();
            else
                Container.Bind<InputService>().To<MobileInputService>().AsSingle();
        }
    }
}
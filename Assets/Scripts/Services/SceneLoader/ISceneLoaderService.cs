using System;

namespace Scripts.Services.SceneLoader
{
    public interface ISceneLoaderService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}
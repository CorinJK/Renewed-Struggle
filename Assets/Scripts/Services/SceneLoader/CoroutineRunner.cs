using UnityEngine;

namespace Scripts.Services.SceneLoader
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void OnEnable() => 
            DontDestroyOnLoad(this);
    }
}
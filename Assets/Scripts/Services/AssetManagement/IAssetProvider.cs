using UnityEngine;

namespace Scripts.Services.AssetManagement
{
    public interface IAssetProvider : IService
    {
        public GameObject Instantiate(string path);
        
        public GameObject Instantiate(string path, Vector3 at);

        public T Instantiate<T>(string path, Vector3 at) where T : MonoBehaviour;
    }
}
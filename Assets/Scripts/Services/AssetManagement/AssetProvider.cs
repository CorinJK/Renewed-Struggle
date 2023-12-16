﻿using UnityEngine;

namespace Scripts.Services.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        } 
        
        public T Instantiate<T>(string path, Vector3 at) where T : MonoBehaviour
        {
            T prefab = Resources.Load<T>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}
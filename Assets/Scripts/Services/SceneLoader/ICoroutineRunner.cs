using System.Collections;
using UnityEngine;

namespace Scripts.Services.SceneLoader
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
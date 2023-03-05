using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Infrastructure
{
    internal sealed class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}
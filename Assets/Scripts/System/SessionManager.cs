using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public abstract class SessionManager : MonoBehaviour
    {
        public static SessionManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            SceneManager.sceneLoaded += OnSceneLoad;
        }

        protected abstract void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode);
    }
}
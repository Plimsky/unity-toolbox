using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class SessionManager : MonoBehaviour
    {
        private int _actualIndexScene;
        private int _nextIndexScene;

        public static SessionManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _actualIndexScene = 0;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.buildIndex == _nextIndexScene && _nextIndexScene != 0)
            {
                SceneManager.UnloadSceneAsync(_actualIndexScene);
                _actualIndexScene = _nextIndexScene;
            }
        }

        public void LoadLevel(int indexLevel)
        {
            _nextIndexScene = indexLevel;
            StartCoroutine(LoadAsynchronusly(indexLevel));
        }

        IEnumerator LoadAsynchronusly(int indexLevel)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(indexLevel, LoadSceneMode.Additive);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                Debug.Log("Progress : " + progress);
                yield return null; // Will wait until the next frame
            }
        }
    }
}
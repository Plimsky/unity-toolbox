using UnityEngine;

namespace System
{
    public abstract class ALevelManager : MonoBehaviour
    {
        #region Events

        public delegate void LevelStartHandler();
        public static event LevelStartHandler OnLevelStart;
        public delegate void LevelEndHandler(bool levelComplete);
        public static event LevelEndHandler OnLevelEnd;

        #endregion

        private void Awake()
        {
            OnLevelStart += SetupLevel;
            OnLevelEnd += ClearLevel;
        }

        public void StartLevel()
        {
            if (OnLevelStart != null)
                OnLevelStart();
        }

        public void EndLevel(bool levelComplete)
        {
            if (OnLevelEnd != null)
                OnLevelEnd(levelComplete);
        }

        protected abstract void SetupLevel();
        protected abstract void ClearLevel(bool levelComplete);
    }
}
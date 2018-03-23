using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace System.UI
{
    // ReSharper disable once InconsistentNaming
    public abstract class AUIState
    {
        protected bool _enabled;
        protected MenuManager _menuManager;

        private Transform _rootTransform;
        private List<GameObject> _listUIElement = new List<GameObject>();

        public AUIState(MenuManager menuManager)
        {
            if (menuManager == null) throw new ArgumentNullException("menuManager");
            _menuManager = menuManager;
        }

        public void Setup(Transform root)
        {
            _rootTransform = root;

            foreach (Transform child in _rootTransform)
            {
                _listUIElement.Add(child.gameObject);
            }

            foreach (var uiElementGameObject in _listUIElement)
            {
                Button button = uiElementGameObject.GetComponent<Button>();
                Slider slider = uiElementGameObject.GetComponent<Slider>();
                MethodInfo methodInfo = GetType().GetMethod(uiElementGameObject.name,
                    BindingFlags.NonPublic | BindingFlags.Instance);

                if (button != null && methodInfo != null)
                {
                    UnityAction action = () => methodInfo.Invoke(this, null);
                    button.onClick.AddListener(action);
                }

                if (slider != null && methodInfo != null)
                {
                    slider.onValueChanged.AddListener(value => { methodInfo.Invoke(this, new object[] {value}); });
                }
            }
        }

        public void Disable()
        {
            _enabled = false;
            _rootTransform.gameObject.SetActive(_enabled);
        }

        public void Enable()
        {
            _enabled = true;
            _rootTransform.gameObject.SetActive(_enabled);
        }

        public bool IsEnabled()
        {
            return _enabled;
        }

        public abstract void Update();
    }
}
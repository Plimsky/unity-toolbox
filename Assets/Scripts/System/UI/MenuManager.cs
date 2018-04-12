using System.Collections.Generic;
using UnityEngine;

namespace System.UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private string _extentionMenuName = "Menu";

        private readonly List<GameObject> _panelMenuList = new List<GameObject>();
        private readonly Dictionary<UIStateEnum, AUIState> _stateDictionary = new Dictionary<UIStateEnum, AUIState>();
        private readonly Stack<UIStateEnum> _stateStack = new Stack<UIStateEnum>();

        private UIStateEnum _actualStateEnum;

        #region Unity Methods

        private void Awake()
        {
            // Get all panels in the root canvas containing the name "Menu" and
            // store them into the _panelMenuList
            FetchPanels(transform, _panelMenuList);

            // Generate a dictionnary of states from thoses panels
            GenerateStates();

            // Add the first newState into the stack states
            _stateStack.Push(GetFirstState());
            _actualStateEnum = GetFirstState();

            DisableAllPanels();
        }

        private void Update()
        {
            if (!_stateDictionary[_stateStack.Peek()].IsEnabled())
                _stateDictionary[_stateStack.Peek()].Enable();
        }

        #endregion

        public void AddState(UIStateEnum newState)
        {
            UpdateState(newState);
            DisableAllPanelsInStack();

            _stateStack.Push(newState);
        }

        public void RemoveLastState(UIStateEnum newState)
        {
            UpdateState(newState);
            DisableAllPanelsInStack();

            _stateStack.Pop();
        }

        private void UpdateState(UIStateEnum state)
        {
            _actualStateEnum = state;
        }

        private void GenerateStates()
        {
            foreach (var panel in _panelMenuList)
            {
                Type typeName = Type.GetType(GetType().Namespace + "." + panel.name + "State");

                if (typeName == null)
                    continue;

                AUIState newAuiState = Activator.CreateInstance(typeName, args: this) as AUIState;

                if (newAuiState != null)
                {
                    newAuiState.Setup(panel.transform);
                    _stateDictionary.Add(newAuiState.State, newAuiState);
                }
            }
        }

        private void FetchPanels(Transform transformElement, List<GameObject> panelList)
        {
            if (transformElement.name.Contains(_extentionMenuName))
                panelList.Add(transformElement.gameObject);

            foreach (Transform childTransform in transformElement)
                FetchPanels(childTransform, panelList);
        }

        private void DisableAllPanels()
        {
            foreach (var state in _stateDictionary)
                state.Value.Disable();
        }

        private void DisableAllPanelsInStack()
        {
            foreach (var uiStateEnum in _stateStack)
                _stateDictionary[uiStateEnum].Disable();
        }

        private UIStateEnum GetFirstState()
        {
            return UIStateEnum.MAINMENU;
        }
    }
}
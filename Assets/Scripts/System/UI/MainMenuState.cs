using UnityEngine;

namespace System.UI
{
    public class MainMenuState : AUIState
    {
        private UIStateEnum _optionsMenu = UIStateEnum.OPTIONSMENU;

        public MainMenuState(MenuManager menuManager) : base(menuManager)
        {
            State = UIStateEnum.MAINMENU;
        }

        private void PlayButton()
        {
            if (!_enabled)
                return;

            SessionManager.Instance.LoadLevel(1);
        }

        private void OptionsButton()
        {
            if (!_enabled)
                return;

            _menuManager.AddState(_optionsMenu);
        }

        private void QuitButton()
        {
            if (!_enabled)
                return;
        }
    }
}
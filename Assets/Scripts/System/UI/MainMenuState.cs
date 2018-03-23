using UnityEngine;

namespace System.UI
{
    public class MainMenuState : AUIState
    {
        private UIStateEnum _optionsMenu = UIStateEnum.OPTIONSMENU;

        public MainMenuState(MenuManager menuManager) : base(menuManager)
        {}

        private void PlayButton()
        {
            if (!_enabled)
                return;
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

        public override void Update()
        {
            throw new NotImplementedException();
        }

    }
}
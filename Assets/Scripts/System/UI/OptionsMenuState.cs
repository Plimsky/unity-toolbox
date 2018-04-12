using UnityEngine;

namespace System.UI
{
    public class OptionsMenuState : AUIState
    {
        private UIStateEnum _mainMenu = UIStateEnum.MAINMENU;

        public OptionsMenuState(MenuManager menuManager) : base(menuManager)
        {
            State = UIStateEnum.OPTIONSMENU;
        }

        private void VolumeSoundSlider(float volume)
        {
            if (!_enabled)
                return;

            Debug.Log("Volume : " + volume);
        }

        private void BackButton()
        {
            if (!_enabled)
                return;

            _menuManager.RemoveLastState(_mainMenu);
        }
    }
}
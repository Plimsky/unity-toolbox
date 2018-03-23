using UnityEngine;

namespace System.UI
{
    public class OptionsMenuState : AUIState
    {
        private UIStateEnum _mainMenu = UIStateEnum.MAINMENU;

        public OptionsMenuState(MenuManager menuManager) : base(menuManager)
        {}

        private void VolumeSoundSlider(float volume)
        {
            Debug.Log("Volume : " + volume);
        }

        private void BackButton()
        {
            _menuManager.RemoveLastState(_mainMenu);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
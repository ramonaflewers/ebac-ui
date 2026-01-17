using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ebac.core.singleton;

namespace Screens
{

    public class screenManager : singleton<screenManager>
    {
        public List<screenBase> screenBases;
        public ScreenType startScreen = ScreenType.Panel;
        private screenBase _currentScreen;


        private void Start() {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
            {
                if(_currentScreen != null) _currentScreen.Hide();

                var nextScreen = screenBases.Find(i => i.screenType == type);

                nextScreen.Show();
                _currentScreen = nextScreen;
            }
            
        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }

}
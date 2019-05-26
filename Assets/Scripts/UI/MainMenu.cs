using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    #region Methods

    // start new game
    public void OnStartButton() {

        MenuManager.GoToMenu(MenuName.GameTypes);
    }

    // load help scene
    public void OnHelpButton() {

        MenuManager.GoToMenu(MenuName.Help);

    }

    // quit game
    public void OnQuitButton() {

        Application.Quit();
    }

    #endregion

}

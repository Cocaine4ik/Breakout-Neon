using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

    #region Methods

    private void Start() {
        // stop the game
        Time.timeScale = 0;
    }

    // resume game, destroy game over menu and go to main menu
    public void OnQuitButton() {

        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    #region Methods
    
    void Start () {
        // stop the game
        Time.timeScale = 0;
	}

	// resume game and destroy pause menu
    public void OnResumeButton() {

        Time.timeScale = 1;
        Destroy(gameObject);

        StatusUtils.IsPause = false;
        AudioManager.Play(AudioClipName.MenuButtonClick);

    }

    // resume game, destroy pause menu and go to main menu
    public void OnQuitButton() {

        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }
    #endregion


}

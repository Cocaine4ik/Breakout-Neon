using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    #region Methods

    // start new game

    private void Start() {

        PlayMusic();
    }

    private void Update() {

        if (!AudioManager.IsPlaying()) {

            StatusUtils.MusicOn = false;

            PlayMusic();
        }

    }
    public void OnStartButton() {

        MenuManager.GoToMenu(MenuName.GameTypes);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    // load help scene
    public void OnHelpButton() {

        MenuManager.GoToMenu(MenuName.Help);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    // quit game
    public void OnQuitButton() {

        Application.Quit();
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    #endregion

    private void PlayMusic() {

        if (!StatusUtils.MusicOn) {

            AudioManager.Play(AudioClipName.MenuMusic);
            StatusUtils.MusicOn = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTypesMenu : MonoBehaviour {

    #region Methods

    public void OnClassicButton() {

        GameMode.IsClassic = true;
        GameMode.IsWacky = false;

        StartTheGame();

        AudioManager.Play(AudioClipName.MenuButtonClick);

    }

    public void OnWackyButton() {

        GameMode.IsClassic = false;
        GameMode.IsWacky = true;

        StartTheGame();

        AudioManager.Play(AudioClipName.MenuButtonClick);

    }

    private void StartTheGame() {

        SceneManager.LoadScene("Level1");

    }
    #endregion
}

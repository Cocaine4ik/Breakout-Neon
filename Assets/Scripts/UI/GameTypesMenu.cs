using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTypesMenu : MonoBehaviour {

    #region Methods

    public void OnClassicButton() {

        GameTypes.IsClassic = true;
        GameTypes.IsWacky = false;

        StartTheGame();

    }

    public void OnWackyButton() {

        GameTypes.IsClassic = false;
        GameTypes.IsWacky = true;

        StartTheGame();

    }

    private void StartTheGame() {

        SceneManager.LoadScene("Level1");

    }
    #endregion
}

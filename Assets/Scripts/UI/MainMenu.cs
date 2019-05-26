using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    #region Methods

    // start new game
    public void OnStartButton() {

        SceneManager.LoadScene("Scene0");
    }

    // quit game
    public void OnQuitButton() {

        Application.Quit();
    }
    #endregion

}

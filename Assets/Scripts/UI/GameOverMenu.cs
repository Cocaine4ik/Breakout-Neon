using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    [SerializeField] Text scoreLabel;
    #region Methods

    private void Start() {

        // stop the game
        Time.timeScale = 0;
        scoreLabel.text = "Score: " + HUD.Scores;
        Debug.Log(StatusUtils.IsGameOver);
        AudioManager.Play(AudioClipName.GameOver, 1);
    }

    // resume game, destroy game over menu and go to main menu
    public void OnQuitButton() {

        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
        AudioManager.Stop();
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

    #endregion


}

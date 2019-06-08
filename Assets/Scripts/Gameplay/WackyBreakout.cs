using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour {

    private void Start() {
        EventManager.StartListening(EventName.GameOver, OnGameOverMenu);

        // stop music plaing when the game started
        AudioManager.Stop();

        StatusUtils.IsGameOver = false;
    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.GameOver, OnGameOverMenu);
    }
    #region Events

    public void OnGameOverMenu(object arg0, object arg1) {

        MenuManager.GoToMenu(MenuName.GameOver);
    }

    #endregion
}

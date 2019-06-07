using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour {

    public static int Score { get; set; }

    private void Start() {
        EventManager.StartListening(EventName.GameOver, OnGameOverMenu);
    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.GameOver, OnGameOverMenu);
    }

    #region Events

    public void OnGameOverMenu(object score, object arg1) {

        MenuManager.GoToMenu(MenuName.GameOver);

        Score = (int)score;
    }

    #endregion
}

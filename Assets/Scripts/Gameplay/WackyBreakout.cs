using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour {

    GameObject[] allBlocks;
    public static int Score { get; set; }

    private void Start() {
        EventManager.StartListening(EventName.GameOver, OnGameOverMenu);

        StatusUtils.IsGameOver = false;
    }

    private void OnDestroy() {
        EventManager.StopListening(EventName.GameOver, OnGameOverMenu);
    }

    private void Update() {

        allBlocks = GameObject.FindGameObjectsWithTag("Block");
        Debug.Log(allBlocks.Length);
        if(allBlocks.Length == 0) {
            EventManager.TriggerEvent(EventName.GameOver, Score);
        }

    }
    #region Events

    public void OnGameOverMenu(object score, object arg1) {

        MenuManager.GoToMenu(MenuName.GameOver);

        Score = (int)score;
    }

    #endregion
}

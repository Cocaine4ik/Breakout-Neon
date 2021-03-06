﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

    public static void GoToMenu(MenuName name) {

        switch(name) {

            case MenuName.Main: SceneManager.LoadScene("MainMenu"); break;
            case MenuName.Pause: Object.Instantiate(Resources.Load("Prefabs/PauseMenu")); break;
            case MenuName.Help: SceneManager.LoadScene("Help"); break;
            case MenuName.GameTypes: SceneManager.LoadScene("GameTypes"); break;
            case MenuName.GameOver: Object.Instantiate(Resources.Load("Prefabs/GameOverMenu")); break;

        }
    }
}

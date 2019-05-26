using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    private void Start() {

        StatusUtils.IsPause = false;

    }
    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape) && StatusUtils.IsPause == false) {

            MenuManager.GoToMenu(MenuName.Pause);
            StatusUtils.IsPause = true;
        }
    }
}

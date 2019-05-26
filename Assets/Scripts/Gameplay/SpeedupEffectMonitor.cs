using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpEffectMonitor : MonoBehaviour {

    #region Fields

    Timer speedUpTimer;
    private bool speedUp;

    #endregion

    #region Properties

    public bool SpeedUp {
        get { return speedUp; }
    }
    #endregion

    #region Methods

    private void Start() {

        speedUpTimer = gameObject.AddComponent<Timer>();
        EventManager.StartListening("SpeedUpEffectActivated", OnSpeedUp);
    }

    private void Update() {
        if(speedUpTimer.Finished) {

            speedUp = false;
        }
        Debug.Log(speedUp);
    }
    private void OnDestroy() {
        EventManager.StopListening("SpeedUpEffectActivated", OnSpeedUp);
    }

    private void OnSpeedUp(object arg0, object arg1) {

        if(!speedUpTimer.Running) {

            speedUpTimer.Duration = (float)arg0;
            speedUpTimer.Run();
            speedUp = true;
        }
        else {

            speedUpTimer.Duration = speedUpTimer.TimeLeft + (float)arg0;
            speedUpTimer.Run();
        }
    }

    #endregion

}

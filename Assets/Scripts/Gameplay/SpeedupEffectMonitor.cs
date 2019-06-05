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
        EventManager.StartListening(EventName.SpeedUpEffectActivated, OnSpeedUp);
    }

    private void Update() {
        if(speedUpTimer.Finished) {

            speedUp = false;
        }
    }
    private void OnDestroy() {
        EventManager.StopListening(EventName.SpeedUpEffectActivated, OnSpeedUp);
    }

    private void OnSpeedUp(object effectDuration, object speedFactor) {

        if(!speedUpTimer.Running) {

            speedUpTimer.Duration = (float)effectDuration;
            speedUpTimer.Run();
            speedUp = true;
        }
        else {

            speedUpTimer.Duration = speedUpTimer.TimeLeft + (float)effectDuration;
            speedUpTimer.Run();
        }
    }

    #endregion

}

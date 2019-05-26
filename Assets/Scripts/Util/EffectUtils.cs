using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUtils{

    #region Fields

    static SpeedUpEffectMonitor speedUpEffectMonitor;

    #endregion

    #region Properties

    public static bool SpeedUp {
        get { return speedUpEffectMonitor.SpeedUp; }
    }
    #endregion

    #region Methods

    public static void Initialize() {
        speedUpEffectMonitor = Camera.main.GetComponent<SpeedUpEffectMonitor>();
    }

    #endregion
}

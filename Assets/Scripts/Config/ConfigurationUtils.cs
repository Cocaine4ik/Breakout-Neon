using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ConfigurationUtils {
    public static ConfigurationData configurationData;

    #region Properties

    public static float PaddleMoveUnitsPerSecond {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifetime {
        get { return configurationData.BallLifetime; }
    }

    public static float MinSpawnTime {
        get { return configurationData.MinSpawnTime; }
    }

    public static float MaxSpawnTime {
        get { return configurationData.MaxSpawnTime; }
    }
    #endregion

    public static void Initialize() {
        configurationData = new ConfigurationData();
    }
}

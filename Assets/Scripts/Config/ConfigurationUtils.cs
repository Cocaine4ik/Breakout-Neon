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

    public static float FreezerEffectDuration {
        get { return configurationData.FreezerEffectDuration; }
    }

    public static float SpeedUpEffectDuration {
        get { return configurationData.SpeedUpEffectDuration; }
    }

    public static float SpeedFactor {
        get { return configurationData.SpeedFactor; }
    }

    public static int StandardBlockPoints {
        get { return configurationData.StandardBlockPoints;  }
    }

    public static int BonusBlockPoints {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int PickupBlockPoints {
        get { return configurationData.PickupBlockPoints; }
    }

    public static int BallsPerGame {
        get { return configurationData.BallsPerGame; }
    }

    #endregion

    public static void Initialize() {
        configurationData = new ConfigurationData();
    }
}
